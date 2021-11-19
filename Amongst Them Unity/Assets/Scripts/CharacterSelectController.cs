using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterSelectController : MonoBehaviour
{
    [SerializeField] Image image;
    bool dropped;
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

}
