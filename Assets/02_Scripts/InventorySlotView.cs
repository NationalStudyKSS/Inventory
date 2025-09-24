using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image _icon;

    public event Action OnInventorySlotRightClicked;
    public event Action<Vector2> OnInventorySlotDragStarted;
    public event Action<Vector2> OnInventorySlotDragging;
    public event Action OnInventorySlotDropped;
    public event Action OnInventorySlotDragEnded;
    public event Action OnInventorySlotHoverStarted;
    public event Action OnInventorySlotHoverEnded;

    /// <summary>
    /// 인벤토리 슬롯의 아이콘을 설정하는 함수
    /// </summary>
    /// <param name="icon"></param>
    public void SetIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }

    /// <summary>
    /// 인벤토리 슬롯의 아이콘을 제거하는 함수
    /// </summary>
    public void ClearIcon()
    {
        _icon.sprite = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnInventorySlotRightClicked?.Invoke();
            //Debug.Log("인벤토리 슬롯 우클릭: " + gameObject.name);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("인벤토리 슬롯 드래그 시작: " + gameObject.name);
            OnInventorySlotDragStarted?.Invoke(eventData.position);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("인벤토리 슬롯 드래그 중: " + gameObject.name);
            OnInventorySlotDragging?.Invoke(eventData.position);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("인벤토리 슬롯 드래그 종료: " + eventData.pointerEnter);
            OnInventorySlotDragEnded?.Invoke();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("인벤토리 슬롯 드롭됨: " + gameObject.name);
            OnInventorySlotDropped?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("마우스 진입: " + gameObject.name);
        OnInventorySlotHoverStarted?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("마우스 퇴장: " + gameObject.name);
        OnInventorySlotHoverEnded?.Invoke();
    }
}