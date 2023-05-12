using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PhotonView))]

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;

    private bool _isControllable = true;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (GetComponent<PhotonView>().IsMine)
        {
            FindObjectOfType<Joystick>().MovmentDirectionCallBack.AddListener(Move);
            FindObjectOfType<Joystick>().MovmentDirectionCallBack.AddListener(Rotate);
        }  
        else
        {
            Destroy(this);
        }
    } 

    private void Move(Vector2 movmentDirection)
    {
        if (_isControllable)
        {
            _rigidbody.AddForce(_speed * movmentDirection, ForceMode2D.Impulse);
        }
    }

    private void Rotate(Vector2 movmentDirection)
    {
        float rotationAmount = Vector3.Cross(movmentDirection.normalized, transform.right).z;

        _rigidbody.angularVelocity = -rotationAmount * _rotationSpeed;
    }
}
