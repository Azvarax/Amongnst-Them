using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3d : MonoBehaviour
{
    public UnityEvent onDownEvent;
    public UnityEvent onUpEvent;

    public void OnMouseDown()
    {
        onDownEvent?.Invoke();
    }

    public void OnMouseUp()
    {
        onUpEvent?.Invoke();
    }

}
