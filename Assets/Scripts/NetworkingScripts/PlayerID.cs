using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public static class PlayerID 
{
    public static int Get() => PhotonNetwork.LocalPlayer.ActorNumber - 1;
}
