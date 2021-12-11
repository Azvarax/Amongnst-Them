using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSelect : MonoBehaviour
{
    [SerializeField] Transform dial;
    [SerializeField] Transform door;
    [SerializeField] SafeSelect safe;
    [SerializeField] float targetAngle;

    public bool LeftButton;
    public bool RightButton;

    Vector3 curAngle;
    float change;
    List<int> numberList = new List<int>();
    bool _completed = false;

    bool direction;
    int comboPosition;
    private void Start()
    {
        GenerateNumbers();
        direction = true;
        comboPosition = 0;
        curAngle = door.eulerAngles;
    }


    private void Update()
    {
        if (_completed)
        {
            return;
        }

        if (direction)
        {
            if (RightButton)
            {
                dial.Rotate(0f, 0f, 120f * Time.deltaTime);
            }
        }
        else
        {
            if (LeftButton)
            {
                dial.Rotate(0f, 0f, 120f * Time.deltaTime);
            }
        }

        if (safe.currentNumber == numberList[comboPosition])
        {
            if (comboPosition == 2)
            {
                _completed = true;
                StartCoroutine(SmoothSetAngle(new Vector3(0f, -20f, 0f)));
            }
            else
            {
                comboPosition++;
            }

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
            door.rotation = Quaternion.Slerp(door.rotation, Quaternion.Euler(angle), 5f * Time.deltaTime);
            //SetAngle(door.eulerAngles + new Vector3(0, 5, 0));
            //yield return new WaitForSeconds(0.5f);
            yield return null;
        }

        door.rotation = Quaternion.Euler(angle);
        StartCoroutine(WinningText.instance.ShowWinText());

    }

    void SetAngle(Vector3 angle)
    {
        door.eulerAngles = angle;
        
    }

    public void leftDown()
    {
        LeftButton = true;
    }

    public void leftUp()
    {
        LeftButton = false;
    }

    public void rightDown()
    {
        RightButton = true;
    }

    public void rightUp()
    {
        RightButton = false;
    }
}
