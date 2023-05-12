using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public sealed class ServerConnector : MonoBehaviourPunCallbacks
{
    public UnityEvent ConnectedToServer;
    
    private void Start() => ConnectToServer();

    private void ConnectToServer() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() => ConnectedToServer.Invoke();
}
