using System.Collections.Generic;
using UnityEngine;

public class MasterGameController : MonoBehaviour
{
    [SerializeField]
    private BaseGameController[] _games;

    private List<BaseGameController> _activeGames = new List<BaseGameController>();

    public BaseGameController SpawnGame(GameZone zone)
    {
        int which = Random.Range(0, _games.Length);

        BaseGameController game = _games[which];

        BaseGameController newGame = Instantiate(game);

        
        newGame.transform.position = new Vector3(
            zone.transform.position.x,
            0f,
            zone.transform.position.z
        );
        newGame.transform.localRotation = zone.transform.localRotation;

        _activeGames.Add(newGame);

        return newGame;
    }
}
