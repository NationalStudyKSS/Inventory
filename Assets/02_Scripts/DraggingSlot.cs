using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 인벤토리에서 아이템을 드래그 할 때 따라다니는 슬롯
/// 이 슬롯 자체에서는 상호작용이 없으므로 MVP 패턴 적용 X
/// </summary>
public class DraggingSlot : MonoBehaviour
{
    [SerializeField] Image _itemIcon; // 드래그 중인 아이템의 아이콘을 표시할 이미지 컴포넌트

    ItemModel _itemModel; // 슬롯에 할당된 아이템 모델
    int _fromSlotIndex; // 아이템이 드래그된 원래 슬롯의 인덱스

    public ItemModel ItemModel => _itemModel; // 슬롯에 할당된 아이템 모델을 외부에서 접근할 수 있는 프로퍼티
    public int FromSlotIndex => _fromSlotIndex; // 아이템이 드래그된 원래 슬롯의 인덱스를 외부에서 접근할 수 있는 프로퍼티

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

    /// <summary>
    /// 아이콘을 설정하는 함수
    /// </summary>
    /// <param name="icon"></param>
    public void SetIcon(Sprite icon)
    {
        _itemIcon.sprite = icon;
    }

    /// <summary>
    /// 아이콘을 제거하는 함수
    /// </summary>
    public void ClearIcon()
    {
        _itemIcon.sprite = null;
    }

    /// <summary>
    /// 선택했을 때의 슬롯 인덱스를 저장하기 위한 함수
    /// </summary>
    /// <param name="index"></param>
    public void SetFromSlotIndex(int index)
    {
        _fromSlotIndex = index;
    }
}