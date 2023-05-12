using UnityEngine;

public sealed class ParticleCreator : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;

    public void CreateParticle()
    {
        Instantiate(_particlePrefab, transform.position, Quaternion.identity);
    }
}
