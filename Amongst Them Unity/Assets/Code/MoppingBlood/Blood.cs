using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mop"))
        {
            BloodMopManager.Instance.HandleBloodCollected();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mop"))
        {
            Destroy(gameObject);
            BloodMopManager.Instance.HandleBloodCollected();
        }
    }
}
