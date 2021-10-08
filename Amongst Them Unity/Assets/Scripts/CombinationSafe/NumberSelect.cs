using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSelect : MonoBehaviour
{
    [SerializeField] Transform dial;
    [SerializeField] SafeSelect safe;

    List<int> numberList = new List<int>();

    bool direction;
    int comboPosition;
    private void Start()
    {
        GenerateNumbers();
        direction = true;
        comboPosition = 0;
    }

    
    private void FixedUpdate()
    {
        if (direction)
        {
            if (Input.GetKey(KeyCode.D))
            {
                dial.Rotate(0f, 0f, 1f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                dial.Rotate(0f, 0f, -1f);
            }
        }

        if (safe.currentNumber == numberList[comboPosition])
        {
            if (comboPosition == 2) { Debug.Log("You Win!"); }
            else
            { comboPosition++; }
            direction = !direction;
        }
    }

    void GenerateNumbers()
    {
        int numb = Random.Range(2, 9);

        numberList.Add(numb);

        numb = Random.Range(1, 9);

        while (numb == numberList[0])
        {
            numb = Random.Range(1, 9);
        }

        numberList.Add(numb);

        numb = Random.Range(1, 9);

        while (numb == numberList[1])
        {
            numb = Random.Range(1, 9);
        }

        numberList.Add(numb);
    }

}
