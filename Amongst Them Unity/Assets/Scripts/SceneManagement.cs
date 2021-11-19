using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Sprite[] VolumeSprites; // 0 is mute, 1 is not mute

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    //see about singleton for settings and how that works out
    public void OnMuteButtonPress(Button button)
    {
        /*
        if(button.name = "Audio_Mute")
        {
            if (GameSettings.audio_on)
                //mute
                button.sprite = 0;
            else
                //unmute
                button.sprite = 1;
        }
        else
            if (GameSettings.music_on)
                //mute
                button.sprite = 0;
            else
                //unmute
                button.sprite = 1;
        */
    }

    public void onResetDefaultSettings()
    {
        /*
         GameSettings,audio_on = true;
        GameSettings.audiolevel = ???;

        GameSettings.music_on = true;
        GameSettings.musiclevel = ???;

         */

    }

    //FIGURE OUT SLIDERS AND HOW THEY WORK

}
