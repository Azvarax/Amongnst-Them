using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinningText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    public static WinningText instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowWinText()
    {
        winText.enabled = true;
        yield return new WaitForSeconds(5f);
        winText.enabled = false;
    }
}
