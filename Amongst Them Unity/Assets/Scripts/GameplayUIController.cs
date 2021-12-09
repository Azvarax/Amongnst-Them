using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] Image[] image;
    // 0 = alive, 1 = captured, 2 = dead, 3 = binoculars, 4 = handcuffs


    bool statusdropped;
    private void Awake()
    {
        statusdropped = false;
    }

    public void HeartClicked()
    {
        if (statusdropped)
        {
            statusdropped = false;
            UnClickStatus();
        }
        else
        {
            statusdropped = true;
            ClickStatus();
        }
    }

    public void ClickStatus()
    {
        for (int index = 0; index < 3; index++)
        {
            image[index].gameObject.SetActive(true);
        }

        image[0].transform.DOLocalMoveY(-613f, 1f, false).SetEase(Ease.OutExpo);
        image[1].transform.DOLocalMoveY(-795f, 1f, false).SetEase(Ease.OutExpo);
        image[2].transform.DOLocalMoveY(-981f, 1f, false).SetEase(Ease.OutExpo);
    }

    public void UnClickStatus()
    {

        image[0].transform.DOLocalMoveY(-1171f, 1f, false).SetEase(Ease.OutExpo);
        image[1].transform.DOLocalMoveY(-1171f, 1f, false).SetEase(Ease.OutExpo);
        image[2].transform.DOLocalMoveY(-1171f, 1f, false).SetEase(Ease.OutExpo);
        for (int index = 0; 0 < 5; index++)
            image[index].gameObject.SetActive(false);
    }

    public void ClickDead()
    {

    }

    public void clickCaptured()
    {

    }
}
