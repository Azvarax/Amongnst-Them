using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SafeButton : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] bool turnsClockwise;
    NumberSelect numberSelect;

    public void Init()
    {
        numberSelect = FindObjectOfType<NumberSelect>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (turnsClockwise)
        {
            numberSelect.rightDown();
        }
        else
        {
            numberSelect.leftDown();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (turnsClockwise)
        {
            numberSelect.rightUp();
        }
        else
        {
            numberSelect.leftUp();
        }
    }
}
