using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private UIEvents _UIEvents;
    public float ControllerOnScreen { get; private set; }
    public void OnDrag(PointerEventData eventData)
    {
        ControllerOnScreen = (eventData.position.x / Screen.width - 0.5f) * 2;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _UIEvents.SendGameContinued();
        ControllerOnScreen = (eventData.position.x / Screen.width - 0.5f) * 2;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(Time.timeScale != 0)
        _UIEvents.SendGameStoped();
    }
}
