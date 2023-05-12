using UnityEngine;

public sealed class PickUpsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _pickupsSpawns;

    [SerializeField] private GameObject _pickupPrefab;

    public int PickupsAmount {get => _pickupsSpawns.Length;}

    private void Start() => SpawnPickUps();

    public void SpawnPickUps()
    {
        for (int i = 0; i < _pickupsSpawns.Length; i++)
        {
            Instantiate(_pickupPrefab, _pickupsSpawns[i].position, Quaternion.identity);
        }
    }
}
