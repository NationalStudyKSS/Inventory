using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 아이템 툴팁을 보여주는 슬롯을 담당하는 클래스
/// 이것도 MVP 패턴을 적용해야 하지만 별도의 상호작용이 없으므로 일단은 생략
/// </summary>
public class ItemDescSlot : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image _itemIconImage;
    [SerializeField] TextMeshProUGUI _itemNameText;
    [SerializeField] TextMeshProUGUI _itemDescText;

    /// <summary>
    /// 아이템 모델을 받아서 해당 모델을 기준으로 UI를 갱신하는 함수
    /// </summary>
    /// <param name="itemModel"></param>
    public void UpdateUI(ItemModel itemModel)
    {
        if (itemModel == null || itemModel.ItemData == null)
        {
            return;
        }

        _itemIconImage.sprite = itemModel.ItemData.ItemIcon;
        _itemNameText.text = itemModel.ItemData.ItemName;
        _itemDescText.text = itemModel.ItemData.ItemDescription;
    }
}