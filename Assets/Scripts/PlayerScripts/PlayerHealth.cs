using UnityEngine.Events;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]

public sealed class PlayerHealth : MonoBehaviour
{
    public UnityEvent<GameObject> Died;

    public UnityEvent Hit;

    public UnityEvent<float> PrecentageUpdated;
    
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    private PhotonView _photonView;

    private void Awake() 
    {
        _photonView = GetComponent<PhotonView>();

        _currentHealth = _maxHealth;

        FindObjectOfType<AlivePlayersCounter>().AddPlayer(gameObject);
    }
    
    public void GetHurt(float damageAmount)
    {
        if (_photonView.IsMine)
        {
            _photonView.RPC("RemoveHealth", RpcTarget.AllBuffered, damageAmount);
        }
    } 
    
    [PunRPC]
    private void RemoveHealth(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0f)
        {
            _photonView.RPC("Die", RpcTarget.AllBuffered);
        }

        Hit.Invoke();

        PrecentageUpdated.Invoke(_currentHealth / _maxHealth);
    }

    [PunRPC]
    private void Die()
    {
        Destroy(gameObject);
        
        Died.Invoke(gameObject);
    }
}
