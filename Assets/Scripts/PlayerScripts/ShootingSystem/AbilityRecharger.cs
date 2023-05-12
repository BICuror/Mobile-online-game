using UnityEngine.Events;
using System.Collections;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]

public sealed class AbilityRecharger : MonoBehaviour
{
    public UnityEvent AbilityActivated;

    [SerializeField] private float _abilityRechargeTime;

    private bool _canActivate = true;

    private bool _active;

    private void Start()
    {
        PhotonView _photonView = GetComponent<PhotonView>();

        if (_photonView.IsMine)
        {   
            FindObjectOfType<BulletImputManager>().StateChanged.AddListener(SetActiveState);
        }
        else 
        {
            Destroy(this);
        }
    }

    public void SetActiveState(bool state)
    {
        _active = state;

        if (_active && _canActivate) ActivateAbility();
    } 

    private void ActivateAbility()
    {
        AbilityActivated.Invoke();

        _canActivate = false;

        StartCoroutine(CooldownAbility());
    }

    private IEnumerator CooldownAbility()
    {
        yield return new WaitForSeconds(_abilityRechargeTime);
    
        _canActivate = true;

        if (_active) ActivateAbility();
    }
}
