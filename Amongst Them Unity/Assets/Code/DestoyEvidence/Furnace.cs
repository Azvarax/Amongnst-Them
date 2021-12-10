using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour

{
	[SerializeField] GameObject Whoosh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrabbableObject>())
        {
            StartCoroutine(WinningText.instance.ShowWinText());

            Destroy(other.gameObject);
            Whoosh.GetComponent<AudioSource>().Play();
        }
    }
}
