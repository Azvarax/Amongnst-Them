using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMopManager : MonoBehaviour
{
    public static BloodMopManager Instance;

    public List<Blood> bloods;

    void Awake()
    {
        Instance = this;
    }

    public void StartBloodGame()
    {
        foreach(Blood blood in bloods)
        {
            blood.gameObject.SetActive(true);
        }
    }

    public void DetermineIfGameComplete()
    {
        if(bloods.Count <= 0)
        {
            print("Winner!");
        }
    }
}
