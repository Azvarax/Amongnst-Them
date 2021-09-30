using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMopManager : MonoBehaviour
{
    public static BloodMopManager Instance;

    public List<Blood> bloods;
    public int bloodCount;

    void Awake()
    {
        Instance = this;
        bloodCount = bloods.Count;
    }

    public void StartBloodGame()
    {
        print("GAME START");
        foreach(Blood blood in bloods)
        {
            blood.gameObject.SetActive(true);
        }
    }

    public void HandleBloodCollected()
    {
        bloodCount--;
        print("bloods left: " + bloodCount);
        if(bloodCount <= 0)
        {
            print("Winner!");
        }
    }
}
