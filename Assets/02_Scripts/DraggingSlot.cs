using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �κ��丮���� �������� �巡�� �� �� ����ٴϴ� ����
/// �� ���� ��ü������ ��ȣ�ۿ��� �����Ƿ� MVP ���� ���� X
/// </summary>
public class DraggingSlot : MonoBehaviour
{
    [SerializeField] Image _itemIcon; // �巡�� ���� �������� �������� ǥ���� �̹��� ������Ʈ

    ItemModel _itemModel; // ���Կ� �Ҵ�� ������ ��
    int _fromSlotIndex; // �������� �巡�׵� ���� ������ �ε���

    public ItemModel ItemModel => _itemModel; // ���Կ� �Ҵ�� ������ ���� �ܺο��� ������ �� �ִ� ������Ƽ
    public int FromSlotIndex => _fromSlotIndex; // �������� �巡�׵� ���� ������ �ε����� �ܺο��� ������ �� �ִ� ������Ƽ

    /// <summary>
    /// ������ ���� �����ϴ� �Լ�
    /// </summary>
    /// <param name="itemModel">�����Կ� �־��� ������ ��</param>
    public void SetItemModel(ItemModel itemModel)
    {
        _itemModel = itemModel;
    }

    /// <summary>
    /// ������ ���� �����ϴ� �Լ�
    /// </summary>
    public void ClearItemModel()
    {
        _itemModel = null;
    }

    /// <summary>
    /// �������� �����ϴ� �Լ�
    /// </summary>
    /// <param name="icon"></param>
    public void SetIcon(Sprite icon)
    {
        _itemIcon.sprite = icon;
    }

    /// <summary>
    /// �������� �����ϴ� �Լ�
    /// </summary>
    public void ClearIcon()
    {
        _itemIcon.sprite = null;
    }

    /// <summary>
    /// �������� ���� ���� �ε����� �����ϱ� ���� �Լ�
    /// </summary>
    /// <param name="index"></param>
    public void SetFromSlotIndex(int index)
    {
        _fromSlotIndex = index;
    }
}