using Cinemachine;
using UnityEngine;

public class CameraTransitTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _currentCinemachine;
    [SerializeField] private CinemachineVirtualCamera _nextCinemachine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _currentCinemachine.Priority = 0;
            _nextCinemachine.Priority = 1;
        }
    }
}
