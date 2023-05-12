using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]

public sealed class ShootingSystem : MonoBehaviour
{
    [SerializeField] private Transform _shootingPoint;

    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _bulletSpeed;

    private PhotonView _photonView;

    private void Start() => _photonView = GetComponent<PhotonView>();

    public void Shoot()
    {
        PhotonNetwork.Instantiate(_bulletPrefab.name, _shootingPoint.position, transform.rotation);
    }
}
