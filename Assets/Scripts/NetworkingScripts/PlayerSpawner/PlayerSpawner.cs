using UnityEngine;
using Photon.Pun;

public sealed class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private Transform[] _playerSpawnPositions;

    private void Start()
    {
        GameObject spawnedPlayer = SpawnPlayer();

        Destroy(this);
    }

    private GameObject SpawnPlayer()
    {
        int index = PlayerID.Get();

        return PhotonNetwork.Instantiate(_playerPrefab.name, _playerSpawnPositions[index].position, Quaternion.identity);
    }
}
