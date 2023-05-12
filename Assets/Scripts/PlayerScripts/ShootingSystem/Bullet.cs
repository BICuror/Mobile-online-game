using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(Rigidbody2D))]

public sealed class Bullet : MonoBehaviour
{
    public UnityEvent HitSomething;

    [SerializeField] private float _damage;

    [SerializeField] private float _bulletSpeed;

    private Rigidbody2D _rigidbody;

    private void Awake()  
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() => transform.position = transform.position + transform.right * _bulletSpeed;

    public Rigidbody2D GetRigidbody() => _rigidbody;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Disappear();

        if (other.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            health.GetHurt(_damage);
        }    
    }

    private void Disappear()
    {
        HitSomething.Invoke();

        Destroy(gameObject);
    }
}
