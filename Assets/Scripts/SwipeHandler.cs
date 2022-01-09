using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public float controllerOnScreen { get; private set; }
    public void OnDrag(PointerEventData eventData)
    {
        controllerOnScreen = (eventData.position.x / Screen.width - 0.5f) * 2;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        MapEvent.SendGameContinued();
        controllerOnScreen = (eventData.position.x / Screen.width - 0.5f) * 2;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(Time.timeScale != 0)
        MapEvent.SendGameStoped();
    }
}
