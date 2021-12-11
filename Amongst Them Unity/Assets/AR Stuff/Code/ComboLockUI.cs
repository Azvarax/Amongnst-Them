using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboLockUI : MonoBehaviour
{
    private ObjectGrabber _objectGrabber;
    [SerializeField] GameObject container;

    void Start()
    {
        //GetComponent<Button>().onClick.AddListener(FindObjectOfType<NumberSelect>().OpenDoor);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (_objectGrabber.potentialObject != null)
    //    {
    //        container.SetActive(true);
    //    }
    //    else
    //    {
    //        container.SetActive(true);
    //    }
    //}
}
