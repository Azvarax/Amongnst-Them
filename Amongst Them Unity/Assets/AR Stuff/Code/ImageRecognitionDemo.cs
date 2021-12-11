using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognitionDemo : MonoBehaviour
{
    [SerializeField] private GameObject[] placeablePrefabs;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager _aRTrackedImageManager;

    [SerializeField] AudioSource confirmAudio;
    [SerializeField] GameObject checkmark;
    bool canShowCheckmark;

    ARTrackedImage currentTrackedImage;
    
    void Awake()
    {
        _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, new Vector3(0,100,0), Quaternion.identity);
            newPrefab.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }

        checkmark.SetActive(false);
        canShowCheckmark = true;
    }

    private void OnEnable()
    {
        _aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {
            UpdateImage(trackedImage);

            if (canShowCheckmark && (trackedImage != currentTrackedImage || currentTrackedImage == null))
            {
                currentTrackedImage = trackedImage;
                StartCoroutine(ShowScanConfirmed());
            }
        }
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in args.removed)
        {
            spawnedPrefabs[trackedImage.name].SetActive(false);
        }
    }

    void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;
        Vector3 rotation = trackedImage.transform.eulerAngles;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;

        if (name == "Game-SafeAR")
        {
            prefab.transform.eulerAngles = rotation;
        }
        prefab.SetActive(true);
    }

    private IEnumerator ShowScanConfirmed()
    {
        confirmAudio.Play();
        checkmark.SetActive(true);
        canShowCheckmark = false;
        yield return new WaitForSeconds(3);
        checkmark.SetActive(false);
        canShowCheckmark = true;
    }
}
