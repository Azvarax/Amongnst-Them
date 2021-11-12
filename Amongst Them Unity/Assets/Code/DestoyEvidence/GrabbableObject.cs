using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransformation = null;
    
    [SerializeField]
    private Transform _rootTransform = null;

    private ObjectGrabber _controller;
    private Rigidbody _rb;

    private Vector3 _previousPosition;
    private Vector3 _currentPosition;
    //public float xAngle, yAngle, zAngle;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _previousPosition = _currentPosition;
        _currentPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Portal>())
        //{
            //LetGo();
        //}
    }

    public void Grab(ObjectGrabber controller)
    {
        _controller = controller;
        _rb.isKinematic = true;
        transform.SetParent(_controller.transform);
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
        if(_targetTransformation != null)
        {
            _rootTransform.SetParent(_targetTransformation);
            _rootTransform.localPosition = Vector3.zero;
            _rootTransform.localEulerAngles = Vector3.zero;
        }
    }

    public void LetGo()
    {
        if (_controller != null)
        {
            _controller.Reset();
        }

        _rb.transform.SetParent(null);
        if (_targetTransformation != null)
        {
            _rootTransform.SetParent(transform);
        }

        _rb.isKinematic = false;
    }

    public void Fling()
    {
        LetGo();
        _rb.AddForce((_currentPosition - _previousPosition) * 2000);
    }
}