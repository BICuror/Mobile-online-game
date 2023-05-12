using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public sealed class LobbyConnector : MonoBehaviourPunCallbacks
{
    public UnityEvent JoinedLobby;

    public void ConnectToLobby() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby() => JoinedLobby.Invoke();
}
