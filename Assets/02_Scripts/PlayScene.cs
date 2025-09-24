using UnityEngine;

/// <summary>
/// 플레이 씬을 총괄하는 최상위 클래스
/// </summary>
public class PlayScene : MonoBehaviour
{
    [SerializeField] QuickSlotController _quickSlotController;
    [SerializeField] InventorySlotController _inventorySlotController;
    [SerializeField] ItemDescSlotController _itemDescSlotController;

    [Header("Temporary")]
    [SerializeField] ItemData[] _itemDatas; // 임시 아이템 데이터 배열

    private void Start()
    {
        _quickSlotController.OnQuickSlotClicked += _inventorySlotController.AddItem; // 퀵슬롯 클릭 이벤트를 인벤토리 슬롯 컨트롤러에 연결
        _inventorySlotController.OnInventorySlotHoverStarted += _itemDescSlotController.ShowItemDescSlot; // 인벤토리 슬롯 호버 시작 이벤트를 아이템 설명 슬롯 컨트롤러에 연결
        _inventorySlotController.OnInventorySlotHoverEnded += _itemDescSlotController.HideItemDescSlot; // 인벤토리 슬롯 호버 종료 이벤트를 아이템 설명 슬롯 컨트롤러에 연결

        InitializeQuickSlot();
        _inventorySlotController.Initialize();
    }

    /// <summary>
    /// 임시) 아이템 데이터를 기반으로 아이템 모델을 생성하고 퀵슬롯 컨트롤러를 초기화하는 함수
    /// </summary>
    void InitializeQuickSlot()
    {
        // 임시 아이템 모델 배열 생성
        ItemModel[] itemModels = new ItemModel[_itemDatas.Length];

        // 임시 아이템 모델 생성
        for (int i = 0; i < _itemDatas.Length; i++)
        {
            ItemModel itemModel = new ItemModel(_itemDatas[i]);
            itemModels[i] = itemModel;
        }

        // 퀵슬롯 컨트롤러 초기화
        _quickSlotController.Initialize(itemModels);
    }
}