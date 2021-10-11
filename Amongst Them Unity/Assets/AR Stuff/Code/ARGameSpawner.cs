using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGameSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject mopGamePrefab;
    public GameObject destroyEvidenceGamePrefab;
    public GameObject combinationLockGamePrefab;

    public Button mopGameButton;
    public Button destroyEvidenceGameButton;

    private void Start()
    {
        mopGameButton.onClick.AddListener(StartMopGame);
        destroyEvidenceGameButton.onClick.AddListener(StartDestroyEvidenceGame);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartMopGame();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartDestroyEvidenceGame();
        }
    }
#endif

    void StartMopGame()
    {
        Instantiate(mopGamePrefab, spawnPoint.position, spawnPoint.rotation, null);
    }

    void StartDestroyEvidenceGame()
    {
        Instantiate(destroyEvidenceGamePrefab, spawnPoint.position, spawnPoint.rotation, null);
    }
}
