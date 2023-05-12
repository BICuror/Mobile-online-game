using UnityEngine.Events;
using UnityEngine;
using Photon.Pun;

public class RoomJoinDetector : MonoBehaviourPunCallbacks
{
    public UnityEvent JoinedRoom;

    public override void OnJoinedRoom() => JoinedRoom.Invoke(); 
}
