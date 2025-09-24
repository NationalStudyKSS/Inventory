using System;
using UnityEngine;

/// <summary>
/// 퀵슬롯에서 UI와 Model간의 연결을 담당하는 중개자 역할 클래스
/// </summary>
public class QuickSlotPresenter : MonoBehaviour
{
    [SerializeField] QuickSlotView _view; // 퀵슬롯 뷰 (UI)

    QuickSlot _quickSlot; // 퀵슬롯 모델

    public event Action<ItemModel> OnQuickSlotClicked; // 퀵슬롯이 클릭되었을 때 발생하는 이벤트

    /// <summary>
    /// 중개자 초기화 시 인덱스와 아이템 모델을 받아 퀵슬롯 모델과 뷰를 초기화하는 함수
    /// </summary>
    /// <param name="index"></param>
    /// <param name="itemModel"></param>
    public void Initialize(int index, ItemModel itemModel)
    {
        _quickSlot = new QuickSlot(index); // 퀵슬롯 모델 생성
        _quickSlot.SetItemModel(itemModel); // 퀵슬롯 모델에 아이템 모델 할당

        _view.OnQuickSlotClicked += QuickSlotClicked; // 뷰의 클릭 이벤트 구독

        _view.Initialize(); // 뷰 초기화
        _view.SetIcon(itemModel.ItemData.ItemIcon); // 뷰에 아이콘 설정
    }

    /// <summary>
    /// view가 눌렸다고 이벤트 발행하면
    /// 그 이벤트를 구독하고 있다가 호출되는 함수
    /// </summary>
    void QuickSlotClicked()
    {
        OnQuickSlotClicked?.Invoke(_quickSlot.ItemModel); // 퀵슬롯 클릭 이벤트 발생, 아이템 모델 전달
        //Debug.Log("QuickSlotPresenter QuickSlotClicked " + gameObject.name);
    }
}