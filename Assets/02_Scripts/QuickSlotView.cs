using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 퀵슬롯의 UI를 담당하는 클래스
/// </summary>
public class QuickSlotView : MonoBehaviour
{
    [SerializeField] Image _icon;
    [SerializeField] Button _button;

    /// <summary>
    /// 퀵슬롯이 눌리면 자신의 Presenter에게 나 눌렸어 알려주는 이벤트
    /// </summary>
    public event Action OnQuickSlotClicked;

    public void Initialize()
    {
        _button.onClick.AddListener(() => QuickSlotClicked());
    }

    /// <summary>
    /// 퀵슬롯의 아이콘을 설정하는 함수
    /// </summary>
    /// <param name="icon"></param>
    public void SetIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }

    /// <summary>
    /// 퀵슬롯의 아이콘을 제거하는 함수
    /// </summary>
    public void ClearIcon()
    {
        _icon.sprite = null;
    }

    /// <summary>
    /// 퀵슬롯이 눌렸을 때 호출되는 함수
    /// 이벤트 발행용
    /// </summary>
    void QuickSlotClicked()
    {
        OnQuickSlotClicked?.Invoke();
        //Debug.Log("QuickSlotClicked" + gameObject.name);
    }
}