using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3d : MonoBehaviour
{
    public Color upTint;
    public Color downTint;
    public Color hoverTint;
    public Renderer buttonRenderer;
    public UnityEvent onDownEvent;
    public UnityEvent onUpEvent;

    private Material _myMaterial;

    private void Awake()
    {
        _myMaterial = buttonRenderer.material;
        _myMaterial.SetColor("_Color", upTint);
    }

    public void OnMouseDown()
    {
        _myMaterial.SetColor("_Color", downTint);
        onDownEvent?.Invoke();
    }

    public void OnMouseUp()
    {
        _myMaterial.SetColor("_Color", upTint);
        onUpEvent?.Invoke();
    }

    public void onHover(bool hovering)
    {
        if(hovering)
        {
            _myMaterial.SetColor("_Color", hoverTint);
        } else
        {
            _myMaterial.SetColor("_Color", upTint);
        }
    }
}
