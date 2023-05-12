using Photon.Pun;
using UnityEngine;

public sealed class RoomCreator : MonoBehaviour
{
    public void CreateRoom(string roomName) => PhotonNetwork.CreateRoom(roomName);
}
