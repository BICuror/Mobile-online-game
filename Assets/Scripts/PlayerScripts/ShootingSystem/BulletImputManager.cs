using UnityEngine.Events;
using UnityEngine;

public sealed class BulletImputManager : MonoBehaviour
{
    public UnityEvent<bool> StateChanged;

    public void ChangeState(bool state) => StateChanged.Invoke(state);
}
