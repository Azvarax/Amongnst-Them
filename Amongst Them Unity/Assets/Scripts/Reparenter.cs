using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparenter : MonoBehaviour
{
    [SerializeField]
    private Transform[] _profileButtons = null;

    public void OnClickProfile(int index)
    {
        _profileButtons[index].SetAsLastSibling();
    }
}
