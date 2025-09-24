using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 인벤토리 슬롯을 나타내는 클래스
/// </summary>
public class InventorySlot
{
    ItemModel _itemModel; // 슬롯에 할당된 아이템 모델
    int _slotIndex; // 슬롯의 인덱스

    public ItemModel ItemModel => _itemModel; // 슬롯에 할당된 아이템 모델을 외부에서 접근할 수 있는 프로퍼티
    public int SlotIndex => _slotIndex; // 슬롯의 인덱스를 외부에서 접근할 수 있는 프로퍼티

    /// <summary>
    /// 인벤토리 슬롯 생성자
    /// 생성 시 슬롯 인덱스를 받아 할당함
    /// </summary>
    /// <param name="index">이 슬롯의 인덱스</param>
    public InventorySlot(int index)
    {
        _slotIndex = index;
    }

    /// <summary>
    /// 아이템 모델을 설정하는 함수
    /// </summary>
    /// <param name="itemModel">퀵슬롯에 넣어줄 아이템 모델</param>
    public void SetItemModel(ItemModel itemModel)
    {
        _itemModel = itemModel;
    }

    /// <summary>
    /// 아이템 모델을 제거하는 함수
    /// </summary>
    public void ClearItemModel()
    {
        _itemModel = null;
    }
}
