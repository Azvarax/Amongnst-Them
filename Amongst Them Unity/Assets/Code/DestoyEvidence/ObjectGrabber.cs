using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private Collider _collider;
    private GrabbableObject _potentialObject;
    private GrabbableObject _grabbedObject;
    private Button3d _myButt;

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
            if (_potentialObject != null)
            {
                _grabbedObject = _potentialObject;
                _grabbedObject.Grab(this);
            }

            if (_myButt != null)
            {
                _myButt.OnMouseDown();
            }
        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (_grabbedObject != null)
            {
                _grabbedObject.Fling();
            }

            if(_myButt != null)
            {
                _myButt.OnMouseUp();
            }
            Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GrabbableObject grabbable = other.GetComponent<GrabbableObject>();
        if(grabbable != null)
        {
            _potentialObject = grabbable;
        }

        Button3d butt = other.GetComponent<Button3d>();
        if(butt)
        {
            _myButt = butt;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_potentialObject != null && other.GetComponent<GrabbableObject>() == _potentialObject)
        {
            _potentialObject = null;
        }

        if (_myButt != null && other.GetComponent<Button3d>() == _myButt)
        {
            _myButt = null;
        }
    }

    public void Reset()
    {
        _potentialObject = null;
        _grabbedObject = null;
    }
}