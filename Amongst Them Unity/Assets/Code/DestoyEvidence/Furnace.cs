using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrabbableObject>())
        {
            print("EVIDENCE DESTROYED");
            Destroy(other.gameObject);
        }
    }
}
