using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotController : MonoBehaviour
{
    [Header ("Inventory Slot Settings")]
    [SerializeField] GameObject _inventorySlotPrefab;
    [SerializeField] Transform _inventorySlotParent;
    [SerializeField] int _slotCount = 36;

    [SerializeField] DraggingSlot _draggingSlot;

    List<InventorySlotPresenter> _inventorySlotPresenters = new();

    public event Action<ItemModel> OnInventorySlotHoverStarted;
    public event Action OnInventorySlotHoverEnded;

    public void Initialize()
    {
        CreateSlots();
    }

    /// <summary>
    /// 인벤토리 슬롯을 생성하는 함수
    /// </summary>
    void CreateSlots()
    {
        for (int i = 0; i < _slotCount; i++)
        {
            GameObject slotObj = Instantiate(_inventorySlotPrefab, _inventorySlotParent);
            slotObj.name = $"InventorySlot_{i}";
            InventorySlotPresenter presenter = slotObj.GetComponent<InventorySlotPresenter>();

            if (presenter != null)
            {
                presenter.Initialize(i, null); // 빈 슬롯 초기화
            }

            if (presenter != null)
            {
                _inventorySlotPresenters.Add(presenter);
            }
        }
    }

    /// <summary>
    /// 아이템 모델을 받아 빈 슬롯에 아이템을 추가하는 함수
    /// </summary>
    /// <param name="itemModel">받아 올 아이템 모델</param>
    public void AddItem(ItemModel itemModel)
    {
        foreach (var presenter in _inventorySlotPresenters)
        {
            // 빈 슬롯을 찾아 아이템을 추가
            if (presenter.InventorySlot.ItemModel != null)
            {
                continue; // 이미 아이템이 있는 슬롯은 건너뜀
            }
            presenter.OnInventorySlotRightClicked += RemoveItem; // 슬롯 우클릭 시 아이템 제거 이벤트 구독
            presenter.OnInventorySlotDragStarted += InventorySlotDragStarted; // 슬롯 드래그 시작 이벤트 구독
            presenter.OnInventorySlotDragging += InventorySlotDragging; // 슬롯 드래그 중 이벤트 구독
            presenter.OnInventorySlotDropped += InventorySlotDropped; // 슬롯 드롭 이벤트 구독
            presenter.OnInventorySlotDragEnded += InventorySlotDragEnded; // 슬롯 드래그 종료 이벤트 구독
            presenter.OnInventorySlotHoverStarted += InventorySlotHoverStarted; // 슬롯 호버 시작 이벤트 구독
            presenter.OnInventorySlotHoverEnded += InventorySlotHoverEnded; // 슬롯 호버 종료 이벤트 구독

            presenter.InventorySlot.SetItemModel(itemModel);
            presenter.InventorySlotView.SetIcon(itemModel.ItemData.ItemIcon);
            Debug.Log(itemModel.ItemData.ItemName + " 아이템이 인벤토리에 추가되었습니다.");
            break; // 아이템을 하나만 추가한 후 루프 종료
        }
    }

    /// <summary>
    /// 인덱스를 받아 해당 슬롯에서 아이템을 제거하는 함수
    /// </summary>
    /// <param name="index"></param>
    public void RemoveItem(int index)
    {
        if (index < 0 || index >= _inventorySlotPresenters.Count)
        {
            Debug.Log("유효하지 않은 인덱스: " + index);
            return; // 인덱스가 유효하지 않으면 종료
        }
        
        if (_inventorySlotPresenters[index].InventorySlot.ItemModel == null)
        {
            Debug.Log(index + "번 슬롯에 아이템이 없습니다.");
            return; // 해당 슬롯에 아이템이 없으면 종료
        }

        InventorySlotPresenter presenter = _inventorySlotPresenters[index];

        presenter.OnInventorySlotRightClicked -= RemoveItem; // 슬롯 우클릭 시 아이템 제거 이벤트 구독 해제
        presenter.OnInventorySlotDragStarted -= InventorySlotDragStarted; // 슬롯 드래그 시작 이벤트 구독 해제
        presenter.OnInventorySlotDragging -= InventorySlotDragging; // 슬롯 드래그 중 이벤트 구독 해제
        presenter.OnInventorySlotDropped -= InventorySlotDropped; // 슬롯 드롭 이벤트 구독 해제
        presenter.OnInventorySlotDragEnded -= InventorySlotDragEnded; // 슬롯 드래그 종료 이벤트 구독 해제
        presenter.OnInventorySlotHoverStarted -= InventorySlotHoverStarted; // 슬롯 호버 시작 이벤트 구독 해제
        presenter.OnInventorySlotHoverEnded -= InventorySlotHoverEnded; // 슬롯 호버 종료 이벤트 구독 해제

        presenter.InventorySlot.ClearItemModel(); // 아이템 모델 제거
        presenter.InventorySlotView.ClearIcon(); // 아이콘 제거
        Debug.Log(index + "번 슬롯의 아이템이 제거되었습니다.");
    }

    /// <summary>
    /// 바꾸려는 두 슬롯의 인덱스를 받아 아이템을 교환하는 함수
    /// </summary>
    /// <param name="fromIndex"></param>
    /// <param name="toIndex"></param>
    public void SwapItems(int fromIndex, int toIndex)
    {
        if (fromIndex < 0 || fromIndex >= _inventorySlotPresenters.Count ||
            toIndex < 0 || toIndex >= _inventorySlotPresenters.Count)
        {
            Debug.Log("유효하지 않은 인덱스: " + fromIndex + " 또는 " + toIndex);
            return; // 인덱스가 유효하지 않으면 종료
        }

        var fromPresenter = _inventorySlotPresenters[fromIndex];
        var toPresenter = _inventorySlotPresenters[toIndex];
        var tempItemModel = fromPresenter.InventorySlot.ItemModel;

        fromPresenter.InventorySlot.SetItemModel(toPresenter.InventorySlot.ItemModel);
        toPresenter.InventorySlot.SetItemModel(tempItemModel);

        // 아이콘 업데이트
        if (fromPresenter.InventorySlot.ItemModel != null)
            fromPresenter.InventorySlotView.SetIcon(fromPresenter.InventorySlot.ItemModel.ItemData.ItemIcon);
        else
            fromPresenter.InventorySlotView.ClearIcon();
        if (toPresenter.InventorySlot.ItemModel != null)
            toPresenter.InventorySlotView.SetIcon(toPresenter.InventorySlot.ItemModel.ItemData.ItemIcon);
        else
            toPresenter.InventorySlotView.ClearIcon();
    }

    /// <summary>
    /// 드래그가 시작되었을 때 호출되는 함수
    /// </summary>
    /// <param name="mousePos">드래그 시작 좌표</param>
    /// <param name="index">드래그 된 슬롯의 인덱스</param>
    void InventorySlotDragStarted(Vector2 mousePos, int index)
    {
        //Debug.Log("드래그 시작");

        ItemModel itemModel = _inventorySlotPresenters[index].InventorySlot.ItemModel;
        _draggingSlot.SetItemModel(itemModel);
        if (itemModel != null)
            _draggingSlot.SetIcon(itemModel.ItemData.ItemIcon);
        else
            _draggingSlot.ClearIcon();
        _draggingSlot.SetFromSlotIndex(index);

        _draggingSlot.transform.position = mousePos;
        _draggingSlot.gameObject.SetActive(true);

        // 원본 슬롯에서 아이템 제거
        //_inventorySlotPresenters[index].InventorySlot.SetItemModel(null);
        //_inventorySlotPresenters[index].InventorySlotView.ClearIcon();
    }

    /// <summary>
    /// 드래그 중일 때 호출되는 함수
    /// </summary>
    /// <param name="mousePos">Dragging Slot이 따라다닐 좌표</param>
    void InventorySlotDragging(Vector2 mousePos)
    {
        //Debug.Log("드래그 중");

        _draggingSlot.transform.position = mousePos;
    }

    /// <summary>
    /// 드래그 하다가 드롭했을 때 호출되는 함수
    /// </summary>
    /// <param name="toIndex">드롭한 인벤토리 슬롯의 인덱스</param>
    void InventorySlotDropped(int toIndex)
    {
        //Debug.Log("드롭");
        ItemModel draggingItemModel = _draggingSlot.ItemModel;
        int fromIndex = _draggingSlot.FromSlotIndex;

        if (draggingItemModel == null || fromIndex == -1)
        {
            Debug.Log("드래그 중인 아이템 또는 시작 슬롯 없음");
            return;
        }

        // 만약 자기 자신에게 드랍하면 복구
        if (fromIndex == toIndex)
        {
            Debug.Log("자기 자신에게 드롭, 복구");
            _inventorySlotPresenters[fromIndex].InventorySlot.SetItemModel(draggingItemModel);
            _inventorySlotPresenters[fromIndex].InventorySlotView.SetIcon(draggingItemModel.ItemData.ItemIcon);
            return;
        }

        // 스왑 처리
        Debug.Log($"아이템 교환: {fromIndex} <-> {toIndex}");
        SwapItems(fromIndex, toIndex);
    }

    /// <summary>
    /// 드래그가 종료되었을 때 호출되는 함수
    /// </summary>
    void InventorySlotDragEnded()
    {
        //Debug.Log("드래그 종료");

        _draggingSlot.gameObject.SetActive(false);
        _draggingSlot.ClearItemModel(); 
        _draggingSlot.ClearIcon();
    }

    /// <summary>
    /// 마우스 오버레이가 시작되었을 때 호출되는 함수
    /// </summary>
    /// <param name="index">마우스 오버레이한 슬롯의 인덱스</param>
    void InventorySlotHoverStarted(int index)
    {
        OnInventorySlotHoverStarted?.Invoke(_inventorySlotPresenters[index].InventorySlot.ItemModel);
    }

    /// <summary>
    /// 마우스 오버레이가 종료되었을 때 호출되는 함수
    /// </summary>
    void InventorySlotHoverEnded()
    {
        OnInventorySlotHoverEnded?.Invoke();
    }
}