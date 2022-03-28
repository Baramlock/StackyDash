using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private StartAnimator _startAnimator;
    private PlayerInput _playerInput;

    private Sequence _sequence;

    public float Speed => _speed;

    public LayerMask LayerMask => _layerMask;

    private void Awake()
    {
        _playerInput = new PlayerInput { };
        _sequence = DOTween.Sequence();
        _startAnimator.StartAnimation(ref _sequence);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.MoveX.performed += ctx => MoveX();
        _playerInput.Player.MoveZ.performed += ctx => MoveZ();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.MoveX.performed -= ctx => MoveX();
        _playerInput.Player.MoveZ.performed -= ctx => MoveZ();
    }

    private void MoveX()
    {
        var direction = _playerInput.Player.MoveX.ReadValue<float>();
        Move(Vector3.right * direction);
    }

    private void MoveZ()
    {
        var direction = _playerInput.Player.MoveZ.ReadValue<float>();
        Move(Vector3.forward * direction);
    }

    private void Move(Vector3 direction)
    {
        if (_sequence.IsActive())
            return;
        _sequence = DOTween.Sequence();
        RayCaster.RayCast(ref _sequence, transform, transform.position, direction, _layerMask);
    }
}
