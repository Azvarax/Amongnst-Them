using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweener : MonoBehaviour
{
    [SerializeField] Image image;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            image.transform.DOLocalMoveY(-100f, 1f, false);
            StartCoroutine(coolDown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            image.transform.DOLocalMoveY(100f, 1f, false).SetEase(Ease.OutElastic);
            StartCoroutine(coolDown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            image.transform.DOShakePosition(.5f, 50f, 10, 120, false, false);
            StartCoroutine(coolDown());
        }
    }

    private IEnumerator coolDown()
    {
        image.color = Color.red;
        yield return new WaitForSeconds(1);
        image.color = Color.green;
    }
}
