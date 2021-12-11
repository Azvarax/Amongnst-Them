using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipHeart : MonoBehaviour
{
    [SerializeField] Image Heart;
    [SerializeField] Sprite[] States; //alive, dead
    bool dead;
    
    public void Flip()
    {
        if (dead)
        {
            Heart.sprite = States[0];
            dead = false;
        }
        else
        {
            Heart.sprite = States[1];
            dead = true;
        }
    }
   
}
