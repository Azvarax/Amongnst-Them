using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    private Image _hand;
    [SerializeField] private Sprite _openHand;
    [SerializeField] private Sprite _closedHand;
    [SerializeField] private HoldButton _holdButton;
    private ObjectGrabber _objectGrabber;

    void Awake()
    {
        _hand = GetComponent<Image>();
        _objectGrabber = FindObjectOfType<ObjectGrabber>();
    }

    private void OnEnable()
    {
        _holdButton.onPointerDown.AddListener(Grab);
        _holdButton.onPointerUp.AddListener(LetGo);
    }

    private void OnDisable()
    {
        _holdButton.onPointerDown.RemoveListener(Grab);
        _holdButton.onPointerUp.RemoveListener(LetGo);
    }

    public void Grab()
    {
        _hand.sprite = _closedHand;
        _objectGrabber.TryGrab();
    }

    public void LetGo()
    {
        _hand.sprite = _openHand;
        _objectGrabber.TryLetGo();
    }
}
