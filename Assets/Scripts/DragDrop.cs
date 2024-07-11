using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,IPointerDownHandler, IDragHandler,IBeginDragHandler,IEndDragHandler ,IDropHandler
{
    RectTransform m_RectTransform;
    CanvasGroup m_CanvasGroup;

    void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_CanvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
        m_CanvasGroup.alpha = .6f;
        m_CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
        m_CanvasGroup.blocksRaycasts = true;
        m_CanvasGroup.alpha = 1f;


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("test mouse1");
    }

}
