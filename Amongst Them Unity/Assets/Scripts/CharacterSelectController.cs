using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CharacterSelectController : MonoBehaviour
{
    [SerializeField] Image image;
    bool dropped;

    [SerializeField] GameObject[] Players;
    int playercount = 5;

    private void Awake()
    {
        dropped = false;
    }

    public void Clicked()
    {
        if (dropped)
        {
            dropped = false;
            UnClickInfo();
        }
        else
        {
            dropped = true;
            ClickInfo();
        }
    }

    public void ClickInfo()
    {
        image.transform.DOLocalMoveY(393f, 1f, false).SetEase(Ease.InOutBack);
        image.transform.DOScaleY(1.33f, 1f).SetEase(Ease.InOutBack);
    }

    public void UnClickInfo()
    {
        image.transform.DOLocalMoveY(1300.454f, 1f, false).SetEase(Ease.InOutBack);
        image.transform.DOScaleY(1f, 1f).SetEase(Ease.InOutBack);
    }
    // Update is called once per frame
    public void ClickDetective()
    {
        GameSettings.investigator = true;
    }
    
    public void ClickMobster()
    {
        GameSettings.investigator = false;
    }

    public void AddPlayer()
    {
        if (playercount < 9)
        {
            playercount++;
            UpdatePlayer();
        }
    }

    public void SubPlayer()
    {
        if (playercount > 5)
        {
            playercount--;
            UpdatePlayer();
        }
    }
    private void UpdatePlayer()
    {
        for(int i = 0; i < 9; i++)
        {
            if (i < playercount) Players[i].gameObject.SetActive(true);
            else Players[i].gameObject.SetActive(false);
        }
    }


    //Timer
    
    // Up and down button cycles by 30 seconds
    // Add player/Subtract player
    //Buttons with Mask - Distraction, Gun - Detective, Click button, cycle through these- , Magnifying P1, Living Status button that cycles, Task completion
    // Minimum of 5, Max of 10


}
