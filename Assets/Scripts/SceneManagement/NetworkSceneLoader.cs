using Photon.Pun;
using UnityEngine;

public sealed class NetworkSceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName) => PhotonNetwork.LoadLevel(sceneName);
}
