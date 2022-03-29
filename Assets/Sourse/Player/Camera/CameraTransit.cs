using Cinemachine;
using UnityEngine;

public class CameraTransit : ActinToTrigger
{
    [SerializeField] private CinemachineVirtualCamera _currentCinemachine;
    [SerializeField] private CinemachineVirtualCamera _nextCinemachine;

    protected override void Action()
    {
        _currentCinemachine.Priority -= 1;
        _nextCinemachine.Priority += 1;
    }
}
