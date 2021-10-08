using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLobby : MonoBehaviour
{
        public void ChangeScene(string SceneName)
        {
        Debug.Log("Hey Fuckers");
             SceneManager.LoadScene(SceneName);
        }

        
}
