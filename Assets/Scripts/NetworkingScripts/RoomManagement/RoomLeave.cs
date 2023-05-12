using Photon.Pun;
using UnityEngine;

public sealed class RoomLeave : MonoBehaviour
{
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
}
