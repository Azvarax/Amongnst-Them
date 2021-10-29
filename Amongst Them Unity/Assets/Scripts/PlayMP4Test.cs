using UnityEngine;
using UnityEngine.Video;

public class PlayMP4Test : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer _player = null;

    private void Awake()
    {
        _player.loopPointReached += onVideoCompleted;
    }

    private void Start()
    {
        _player.Play();
    }

    private void onVideoCompleted(VideoPlayer source)
    {
        Debug.Log("Finished");
    }
}
