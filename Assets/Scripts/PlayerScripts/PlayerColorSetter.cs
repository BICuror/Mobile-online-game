using UnityEngine;
using Photon.Pun;

public sealed class PlayerColorSetter : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    public void SetPlayerColor(GameObject player)
    {
        int playerIndex = player.GetComponent<PhotonView>().Owner.ActorNumber - 1;

        player.GetComponent<PlayerColorChanger>().SetPlayerColor(_colors[playerIndex]);
    }
}
