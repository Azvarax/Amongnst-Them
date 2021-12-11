using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeratorTimer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    float seconds;
    float NextTime = 0;
    int secondsleft;
    string StrSecondsLeft;


    void Update()
    {
        if (NextTime != 0)
        {

            if (NextTime > 0 && Time.time > NextTime)
            {
                NextTime = 0;
            }
            else
            {
                secondsleft = Mathf.FloorToInt(NextTime - Time.time) % 60;
                StrSecondsLeft = secondsleft.ToString("00");
                TimerText.text = $"{Mathf.FloorToInt(NextTime - Time.time) / 60}:{StrSecondsLeft}";
            }
        }
    }

    public void AddTime()
    {
        seconds += 30;
        TimerText.text = $"{Mathf.FloorToInt(seconds) / 60}:{(seconds % 60).ToString("00")}";
    }

    public void SubTime()
    {
        if (seconds != 0)
        {
            seconds -= 30;
            TimerText.text = $"{Mathf.FloorToInt(seconds) / 60}:{(seconds % 60).ToString("00")}";
        }
    }

    public void StopTimer()
    {
        NextTime = 0;
    }

    public void StartTimer()
    {
        NextTime = seconds + Time.time;
    }
}
