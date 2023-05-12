using UnityEngine.Events;
using UnityEngine;

public sealed class PickUp : MonoBehaviour
{   
    public UnityEvent Picked;

    public void PickedUp()
    {
        Picked.Invoke(); 

        Destroy(gameObject);
    }
}
