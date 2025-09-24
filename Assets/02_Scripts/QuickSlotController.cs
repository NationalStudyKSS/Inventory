using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 퀵슬롯 시스템을 총괄하는 Controller 클래스
/// </summary>
public class QuickSlotController : MonoBehaviour
{
    [Header("QuickSlot Settings")]
    [SerializeField] GameObject _quickSlotPrefab;
    [SerializeField] Transform _quickSlotParent;

    [SerializeField] int _slotCount = 5;

    List<QuickSlotPresenter> _quickSlotPresenter = new();

    [Header("Temporary")]
    ItemModel[] itemModels; // 임시 아이템 모델 배열

    public event Action<ItemModel> OnQuickSlotClicked; // 퀵슬롯이 클릭되었을 때 발생하는 이벤트

    public void Initialize(ItemModel[] itemModels)
    {
        CreateSlots(itemModels);
    }

    /// <summary>
    /// 퀵슬롯을 생성하는 함수
    /// 현재는 임시로 아이템 모델 배열을 받아 슬롯을 생성함
    /// </summary>
    /// <param name="itemModels">임시로 받아온 아이템 모델 배열</param>
    public void CreateSlots(ItemModel[] itemModels)
    {
        for (int i = 0; i < _slotCount; i++)
        {
            GameObject slotObj = Instantiate(_quickSlotPrefab, _quickSlotParent);
            slotObj.name = $"QuickSlot_{itemModels[i].ItemData.ItemId}";
            QuickSlotPresenter presenter = slotObj.GetComponent<QuickSlotPresenter>();

            presenter.OnQuickSlotClicked += QuickSlotClicked; // 퀵슬롯 클릭 이벤트 구독

            if (i < itemModels.Length)
            {
                presenter.Initialize(i, itemModels[i]);
            }
            else
            {
                presenter.Initialize(i, new ItemModel(null)); // 빈 슬롯 초기화
            }

            if (presenter != null)
            {
                _quickSlotPresenter.Add(presenter);
            }
        }
    }

    public void QuickSlotClicked(ItemModel itemModel)
    {
        OnQuickSlotClicked?.Invoke(itemModel); // 퀵슬롯 클릭 이벤트 발생, 아이템 모델 전달
        //Debug.Log("QuickSlotController QuickSlotClicked " + quickSlot.SlotIndex);
    }
}