using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class СameraDistance : MonoBehaviour
{
    [SerializeField] private ChildCase _childCase;
    [SerializeField] private float _distantCoefficient = 1;
    private CinemachineVirtualCamera _virtualCamera;
    private float _startFieldOfViem;
    private int _startChild;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _startFieldOfViem = _virtualCamera.m_Lens.FieldOfView;
        _startChild = _childCase.ChildCount;
    }

    private void OnEnable()
    {
        Player.BlockAdded += AddDistant;
        Player.BlockRemove += RemoveDistant;
    }

    private void OnDisable()
    {
        Player.BlockAdded -= AddDistant;
        Player.BlockRemove -= RemoveDistant;
    }

    private void AddDistant()
    {
        _virtualCamera.m_Lens.FieldOfView += (_startFieldOfViem / _startChild) * _distantCoefficient;
    }

    private void RemoveDistant()
    {
        _virtualCamera.m_Lens.FieldOfView -= (_startFieldOfViem / _startChild) * _distantCoefficient;
    }
}
