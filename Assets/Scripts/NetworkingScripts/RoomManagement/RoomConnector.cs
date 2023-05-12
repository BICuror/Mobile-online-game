using Photon.Pun;
using UnityEngine;

public sealed class RoomConnector : MonoBehaviour
{
    public void JoinRoom(string roomName) => PhotonNetwork.JoinRoom(roomName);
}
