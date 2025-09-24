using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������ ������ �����ִ� ������ ����ϴ� Ŭ����
/// �̰͵� MVP ������ �����ؾ� ������ ������ ��ȣ�ۿ��� �����Ƿ� �ϴ��� ����
/// </summary>
public class ItemDescSlot : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image _itemIconImage;
    [SerializeField] TextMeshProUGUI _itemNameText;
    [SerializeField] TextMeshProUGUI _itemDescText;

    /// <summary>
    /// ������ ���� �޾Ƽ� �ش� ���� �������� UI�� �����ϴ� �Լ�
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