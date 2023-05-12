using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public sealed class AlivePlayersCounter : MonoBehaviour
{
    public UnityEvent<GameObject> OnePlayerLeft;

    public UnityEvent<GameObject> PlayerAdded;

    private List<GameObject> _players = new List<GameObject>();

    public void AddPlayer(GameObject playerToAdd)
    {
        _players.Add(playerToAdd);

        playerToAdd.GetComponent<PlayerHealth>().Died.AddListener(RemovePlayer);
    
        PlayerAdded.Invoke(playerToAdd);
    }

    private void RemovePlayer(GameObject player)
    {
        _players.Remove(player);

        if (_players.Count == 1) OnePlayerLeft.Invoke(_players[0]);
    }
}
