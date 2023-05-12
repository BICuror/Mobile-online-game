using UnityEngine;
using UnityEngine.Events;

public sealed class PickUpsCollector : MonoBehaviour
{
    public UnityEvent<float> PrecentageUpdated;

    private int _collectedPickups;
    public int CollectedPickUps {get => _collectedPickups;}

    private int _pickUpsOnMap;
    public int PickUpsOnMap {get => _pickUpsOnMap;}

    private void Awake() => _pickUpsOnMap = FindObjectOfType<PickUpsSpawner>().PickupsAmount;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.TryGetComponent<PickUp>(out PickUp pickUp))
        {
            _collectedPickups++;

            pickUp.PickedUp();

            PrecentageUpdated.Invoke((float)_collectedPickups / (float)_pickUpsOnMap);
        }    
    }
}
