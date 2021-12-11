using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskScroller : MonoBehaviour
{
    public TextMeshProUGUI countertext; //help me
    int counter;

    public void CycleNumber()
    {
        if (++counter > GameSettings.totaltasks)
            counter = 0;

        countertext.text = $"{counter}";
    }
}
