using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSelect : MonoBehaviour
{
    [SerializeField] Transform dial;
    [SerializeField] Transform door;
    [SerializeField] SafeSelect safe;
    [SerializeField] float targetAngle;

    Vector3 curAngle;
    float change;
    List<int> numberList = new List<int>();

    bool direction;
    int comboPosition;
    private void Start()
    {
        GenerateNumbers();
        direction = true;
        comboPosition = 0;
        curAngle = door.eulerAngles;
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
            if (comboPosition == 2)
            {
                StartCoroutine(SmoothSetAngle(new Vector3(0, 120, 0)));
            }
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

    IEnumerator SmoothSetAngle(Vector3 angle)
    {
        while(door.eulerAngles != angle)
        {
            SetAngle(door.eulerAngles + new Vector3(0, 5, 0));
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SetAngle(Vector3 angle)
    {
        door.localEulerAngles = angle;
    }

    public void OpenDoor()
    {
        SetAngle(new Vector3(0, 120, 0));
    }
}
