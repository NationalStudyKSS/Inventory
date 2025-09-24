using UnityEngine;

/// <summary>
/// 아이템 툴팁을 보여주는 슬롯을 제어하는 클래스
/// </summary>
public class ItemDescSlotController : MonoBehaviour
{
    [SerializeField] ItemDescSlot _itemDescSlot; // 아이템 툴팁 슬롯 뷰

    public void ShowItemDescSlot(ItemModel itemModel)
    {
        _itemDescSlot.UpdateUI(itemModel); // 아이템 모델을 받아서 UI 갱신

        if(itemModel == null) return; // 아이템 모델이 null이면 슬롯 비활성화

        _itemDescSlot.gameObject.SetActive(true); // 슬롯 활성화
    }

    public void HideItemDescSlot()
    {
        _itemDescSlot.gameObject.SetActive(false); // 슬롯 비활성화
    }
}
