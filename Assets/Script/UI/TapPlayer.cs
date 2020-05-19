using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapPlayer : MonoBehaviour, IPointerDownHandler
{
    public Action action = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        action();
    }
}
