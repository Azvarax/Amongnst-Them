using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BloodMopManager.Instance.HandleBloodCollected();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        BloodMopManager.Instance.HandleBloodCollected();
    }
}
