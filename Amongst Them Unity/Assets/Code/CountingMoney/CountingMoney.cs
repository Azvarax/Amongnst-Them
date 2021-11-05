using System.Collections.Generic;
using UnityEngine;

public class CountingMoney : MonoBehaviour

{
    [SerializeField]
    private AudioSource countingSource;
    
    [SerializeField]
    private GameObject PileofMoney;

    [SerializeField]
    private Transform pileLocator;

    private List<GameObject> _wads;

    private void Awake()
    {
        _wads = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrabbableObject>())
        {
            AddCash(other.gameObject);
            print("Money Counted");
        }
    }

    public void AddCash(GameObject wad)
    {
        if (_wads.Contains(wad))
        {
            return;
        }
        _wads.Add(wad);

        if(_wads.Count > 4)
        {
            countingSource.Play();

            foreach (GameObject w in _wads)
            {
                Destroy(w);
            }

            GameObject pile = Instantiate(PileofMoney,pileLocator);
            pile.transform.localPosition = Vector3.zero;
            pile.transform.localRotation = Quaternion.identity;
        }
    }
}
