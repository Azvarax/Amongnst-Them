using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] Image[] image;
    // 0 = alive, 1 = captured, 2 = tool
    [SerializeField] Sprite[] tools;
    // 0 = binocular, 1 = handcuff
    [SerializeField] Image[] bullets;
    [SerializeField] Sprite[] checks;
    // 0 = empty, 1 = checked
    public Image projector;
    public Image jailcell;
    public Image Captured;
    public TextMeshProUGUI CountDowner;
    
    Color invis;
    Color dim;
    bool tooldropped;
    bool statusdropped;
    bool investigator;
    bool tasklistdropped;
    bool CaptureUsed;
    bool CoolDown;
    float CapturedAssetTimer = 6;
    float CoolDownTimer = 25;
    private float NextCaptureTimer;
    private float NextCoolDownTimer;
    int bulletcount = 0;

    Vector3 CapturedDefaultSize;
    private void Awake()
    {
        investigator = GameSettings.investigator;
        CapturedDefaultSize = new Vector3(.1476f, .1476f, .1476f);
        dim = new Color(34/255f, 34/255f, 34/255f);
        if (!investigator) image[2].sprite = tools[0]; else image[2].sprite = tools[1];
        tooldropped = false;
        statusdropped = false;
        invis = image[0].color; 
        invis.a = 0f;
        image[0].color = invis;
        image[1].color = invis;
        image[2].color = invis;
    }

    private void Update()
    {
        if(CaptureUsed)
        {
            if (NextCaptureTimer > 0 && Time.time > NextCaptureTimer)
            { 
                Captured.gameObject.SetActive(false);
                Captured.transform.localScale = CapturedDefaultSize;
                NextCaptureTimer = 0;
            }
        }
        if (CoolDown)
        {
            if(NextCoolDownTimer > 0 && Time.time > NextCoolDownTimer)
            {
                CoolDown = false;
                NextCoolDownTimer = 0;
                CountDowner.text = "";
                image[2].color = Color.white;
            }
            else
            {
                CountDowner.text = $"{Mathf.FloorToInt(NextCoolDownTimer - Time.time)}";
            }
        }
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
        for (int index = 0; index <2; index++)
            image[index].DOFade(1f, 1f).SetEase(Ease.OutExpo);
        image[0].transform.DOLocalMoveY(-742f, 1f, false).SetEase(Ease.OutQuart);
        image[1].transform.DOLocalMoveY(-928f, 1f, false).SetEase(Ease.OutQuart);
    }

    public void UnClickStatus()
    {
        for (int index = 0; index < 2; index++)
            image[index].DOFade(0f, 1f).SetEase(Ease.InExpo);
        image[0].transform.DOLocalMoveY(-1113f, 1f, false).SetEase(Ease.OutQuart);
        image[1].transform.DOLocalMoveY(-1113f, 1f, false).SetEase(Ease.OutQuart);
    }


    public void clickToolBox()
    {
        if (!tooldropped)
        {
            tooldropped = true;
            image[2].DOFade(1f, 1f).SetEase(Ease.OutExpo);
            image[2].transform.DOLocalMoveX(300f, 1f, false).SetEase(Ease.OutQuart);
        }
        else
        {
            tooldropped = false;
            image[2].DOFade(0f, 1f).SetEase(Ease.InExpo);
            image[2].transform.DOLocalMoveX(465f, 1f, false).SetEase(Ease.OutQuart);
        }
    }

    public void clickTool()
    {
        if (investigator)
        {
            if (!CoolDown)
            {
                Captured.gameObject.SetActive(true);
                Captured.transform.DOScale(.4f, 1f).SetEase(Ease.OutExpo);
                Debug.Log($"Set {image[2].name} color to {dim}");
                image[2].color = dim;
                CaptureUsed = true;
                CoolDown = true;
                NextCaptureTimer = Time.time + CapturedAssetTimer;
                NextCoolDownTimer = Time.time + CoolDownTimer;
            }
        }
        else
        {
            //MATT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!scan task bring up task
        }
    }

    public void Dropdown()
    {
        if (tasklistdropped)
        {
            tasklistdropped = false;
            projector.transform.DOLocalMoveY(736f, 1f, false).SetEase(Ease.InOutBack);
            projector.transform.DOScaleY(1f, 1f).SetEase(Ease.InOutBack);
        }
        else
        {
            tasklistdropped = true;
            projector.transform.DOLocalMoveY(1459f, 1f, false).SetEase(Ease.InOutBack);
            projector.transform.DOScaleY(1f, 1f).SetEase(Ease.InOutBack);
        }
    }

    public void TaskUpdate() //MATT INCREMENT GameSettings.taskscomplete++ AND ALSO CALL THIS FUNCTION UPON TASK COMPLETION HOPE IT WORKS
    {
        bulletcount = GameSettings.taskscomplete;
        for(int i = 0; i < 5; i++)
        {
            if (i < bulletcount) bullets[i].sprite = checks[1];
            else bullets[i].sprite = checks[0];
        }
    }
    
    public void onCapture()
    {
        jailcell.transform.DOScaleX(1f, 1.5f).SetEase(Ease.OutBounce);
    }
}