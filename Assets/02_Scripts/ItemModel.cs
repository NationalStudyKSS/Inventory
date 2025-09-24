
/// <summary>
/// 아이템의 로직을 담당하는 클래스
/// </summary>
public class ItemModel
{
    ItemData _itemData; // 아이템의 데이터

    public ItemData ItemData => _itemData; // 아이템의 데이터를 외부에서 접근할 수 있는 프로퍼티

    /// <summary>
    /// 아이템 모델을 생성하는 생성자
    /// </summary>
    /// <param name="itemData">이 모델이 갖게될 아이템 데이터</param>
    public ItemModel(ItemData itemData)
    {
        _itemData = itemData;
    }
}