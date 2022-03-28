using DG.Tweening;
using UnityEngine;

public abstract class ActionMovement : MonoBehaviour
{
    [field: SerializeField] protected PlayerMovement PlayerMovement { get; private set; }

    protected float Speed { get; private set; }

    public abstract void PerformingActions(ref Sequence sequence, Transform player, Vector3 direction, Vector3 origin);

    private void Awake()
    {
        Speed = PlayerMovement.Speed;
    }
}