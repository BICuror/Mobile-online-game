using UnityEngine.Events; 
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public sealed class PlayerCounter : MonoBehaviourPunCallbacks
{
    public UnityEvent EnoughPlayersJoined;

    [SerializeField] private int _neededAmoutOfPlayersToStart;

    private void Awake() => CountPlayers();

    public override void OnPlayerEnteredRoom (Player newPlayer) => CountPlayers();

    public void CountPlayers()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == _neededAmoutOfPlayersToStart)
        {
            EnoughPlayersJoined.Invoke();
        }
    }
}
