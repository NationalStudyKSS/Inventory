using System;
using UnityEngine;

public class InventorySlotPresenter : MonoBehaviour
{
    [SerializeField] InventorySlotView _view; // 인벤토리 슬롯 뷰

    InventorySlot _inventorySlot; // 인벤토리 슬롯 모델

    public InventorySlotView InventorySlotView => _view; // 인벤토리 슬롯 뷰에 대한 퍼블릭 접근자
    public InventorySlot InventorySlot => _inventorySlot; // 인벤토리 슬롯 모델에 대한 퍼블릭 접근자

    public event Action<int> OnInventorySlotRightClicked; // 인벤토리 슬롯이 우클릭되었을 때 발생하는 이벤트
    public event Action<Vector2, int> OnInventorySlotDragStarted; // 인벤토리 슬롯 드래그 시작 이벤트
    public event Action<Vector2> OnInventorySlotDragging; // 인벤토리 슬롯 드래그 중 이벤트
    public event Action<int> OnInventorySlotDropped; // 인벤토리 슬롯 드롭 이벤트
    public event Action OnInventorySlotDragEnded; // 인벤토리 슬롯 드래그 종료 이벤트
    public event Action<int> OnInventorySlotHoverStarted; // 인벤토리 슬롯에 마우스가 올라갔을 때 발생하는 이벤트
    public event Action OnInventorySlotHoverEnded; // 인벤토리 슬롯에서 마우스가 벗어났을 때 발생하는 이벤트

    /// <summary>
    /// 중개자 초기화 시 인덱스와 아이템 모델을 받아 인벤토리 슬롯 모델과 뷰를 초기화하는 함수
    /// </summary>
    /// <param name="index"></param>
    /// <param name="itemModel"></param>
    public void Initialize(int index, ItemModel itemModel)
    {
        _inventorySlot = new InventorySlot(index); 

        _view.OnInventorySlotRightClicked += InventorySlotRightClicked; // 뷰의 우클릭 이벤트 구독
        _view.OnInventorySlotDragStarted += InventorySlotDragStarted; // 뷰의 드래그 시작 이벤트 구독
        _view.OnInventorySlotDragging += InventorySlotDragging; // 뷰의 드래그 중 이벤트 구독
        _view.OnInventorySlotDropped += InventorySlotDropped; // 뷰의 드롭 이벤트 구독
        _view.OnInventorySlotDragEnded += InventorySlotDragEnded; // 뷰의 드래그 종료 이벤트 구독
        _view.OnInventorySlotHoverStarted += InventorySlotHoverStarted; // 뷰의 호버 시작 이벤트 구독
        _view.OnInventorySlotHoverEnded += InventorySlotHoverEnded; // 뷰의 호버 종료 이벤트 구독

        _inventorySlot.SetItemModel(itemModel);

        if (itemModel != null)
            _view.SetIcon(itemModel.ItemData.ItemIcon);
        else
            _view.ClearIcon();
    }

    /// <summary>
    /// 인벤토리 슬롯에서 우클릭 이벤트가 발생했을 때 호출되는 함수
    /// </summary>
    void InventorySlotRightClicked()
    {
        OnInventorySlotRightClicked?.Invoke(_inventorySlot.SlotIndex); // 인벤토리 슬롯 우클릭 이벤트 발생, 아이템 모델 전달
        //Debug.Log("InventorySlotPresenter InventorySlotRightClicked " + gameObject.name);
    }

    /// <summary>
    /// 인벤토리 슬롯에서 드래그 시작 이벤트가 발생했을 때 호출되는 함수
    /// </summary>
    void InventorySlotDragStarted(Vector2 mousePos)
    {
        OnInventorySlotDragStarted?.Invoke(mousePos, _inventorySlot.SlotIndex); 
        //Debug.Log("InventorySlotPresenter InventorySlotDragStarted " + gameObject.name);
    }

    /// <summary>
    /// 인벤토리 슬롯에서 드래그 중 이벤트가 발생했을 때 호출되는 함수
    /// </summary>
    void InventorySlotDragging(Vector2 mousePos)
    {
        OnInventorySlotDragging?.Invoke(mousePos);
        //Debug.Log("InventorySlotPresenter InventorySlotDragging " + gameObject.name);
    }

    void InventorySlotDropped()
    {
        OnInventorySlotDropped?.Invoke(_inventorySlot.SlotIndex); // 이벤트 발행
        //Debug.Log("InventorySlotPresenter InventorySlotDropped " + gameObject.name);
    }

    /// <summary>
    /// 인벤토리 슬롯에서 드래그 종료 이벤트가 발생했을 때 호출되는 함수
    /// </summary>
    void InventorySlotDragEnded()
    {
        OnInventorySlotDragEnded?.Invoke();
        //Debug.Log("InventorySlotPresenter InventorySlotDragEnded " + gameObject.name);
    }

    /// <summary>
    /// 인벤토리 슬롯에서 호버 시작 이벤트가 발생했을 때 호출되는 함수
    /// </summary>
    void InventorySlotHoverStarted()
    {   
        OnInventorySlotHoverStarted?.Invoke(_inventorySlot.SlotIndex); // 인벤토리 슬롯 호버 시작 이벤트 발생, 아이템 모델 전달
    }

    /// <summary>
    /// 인벤토리 슬롯에서 호버 종료 이벤트가 발생했을 때 호출되는 함수
    /// </summary>
    void InventorySlotHoverEnded()
    {
        OnInventorySlotHoverEnded?.Invoke(); // 인벤토리 슬롯 호버 종료 이벤트 발생, 아이템 모델 전달
    }
}