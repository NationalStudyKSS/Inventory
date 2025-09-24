using UnityEngine;

/// <summary>
/// 아이템의 데이터를 저장하는 클래스
/// </summary>
[CreateAssetMenu(fileName = "ItemData", menuName = "GameSettings/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] string _itemId;   // 아이템 고유 ID
    [SerializeField] string _itemName; // 아이템 이름
    [SerializeField] Sprite _itemIcon; // 아이템 아이콘 이미지
    [TextArea(3,5)] [SerializeField] string _itemDescription; // 아이템 설명

    public string ItemId => _itemId;
    public string ItemName => _itemName;
    public Sprite ItemIcon => _itemIcon;
    public string ItemDescription => _itemDescription;
}