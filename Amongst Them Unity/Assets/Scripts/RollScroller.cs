using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollScroller : MonoBehaviour
{
    public Sprite[] roleSprites; // Mafia, Distraction, Detective
    private int _roleIndex = 0;
    public Image buttonImage;

public void CycleRole()
    {
        if (++_roleIndex >= roleSprites.Length)
        {
            _roleIndex = 0;
        }

        buttonImage.sprite = roleSprites[_roleIndex];
    }
}
