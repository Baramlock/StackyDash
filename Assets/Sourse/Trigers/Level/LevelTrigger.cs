using UnityEngine;
using UnityEngine.Events;

public class LevelTrigger : MonoBehaviour
{
    public event UnityAction<Collider> Enter;

    public void OnTriggerEnter(Collider other)
    {
        Enter?.Invoke(other);
    }
}
