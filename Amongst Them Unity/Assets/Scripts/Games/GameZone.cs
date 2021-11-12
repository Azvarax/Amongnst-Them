using UnityEngine;

public class GameZone : MonoBehaviour
{
    [SerializeField]
    private MasterGameController _controller = null;

    private BaseGameController _game;

    public void OnTriggerEnter(Collider other)
    {
        if (_game == null)
        {
            if (other.CompareTag("Player"))
            {
                _game = _controller.SpawnGame(this);
            }
        }
    }
}
