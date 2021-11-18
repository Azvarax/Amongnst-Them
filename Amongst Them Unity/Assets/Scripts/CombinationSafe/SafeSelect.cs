using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSelect : MonoBehaviour
{
    public int currentNumber;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Number")
        {
            currentNumber = other.gameObject.GetComponent<SafeNumbers>().index;
            //Debug.Log("Safe number: " + other.gameObject.GetComponent<SafeNumbers>().index);
        }
    }
}
