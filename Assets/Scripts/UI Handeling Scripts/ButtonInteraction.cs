using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Vector3 growMax;
    [SerializeField] Vector3 growMin;
    [SerializeField] float time;
    // Called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.transform.DOScale(growMax, time);
    }

    // Called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.transform.DOScale(growMin, time);
    }
}
