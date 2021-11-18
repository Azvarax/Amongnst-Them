using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private Collider _collider;
    [HideInInspector] public GrabbableObject potentialObject;
    private GrabbableObject _grabbedObject;


    void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _collider.enabled = false;
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            _collider.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryGrab();
        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
            TryLetGo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GrabbableObject grabbable = other.GetComponent<GrabbableObject>();
        if(grabbable != null)
        {
            potentialObject = grabbable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (potentialObject != null && other.GetComponent<GrabbableObject>() == potentialObject)
        {
            potentialObject = null;
        }
    }

    public void Reset()
    {
        potentialObject = null;
        _grabbedObject = null;
    }

    public void TryGrab()
    {
        if (potentialObject != null)
        {
            _grabbedObject = potentialObject;
            _grabbedObject.Grab(this);
        }
    }

    public void TryLetGo()
    {
        if (_grabbedObject != null)
        {
            _grabbedObject.Fling();
        }
        Reset();
    }
}