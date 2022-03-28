using DG.Tweening;
using UnityEngine;

public class Arrow : Corner
{
    [SerializeField] private Transform _direction;

    protected override void RayCastNewPosition(ref Sequence sequence, Transform player, Vector3 direction)
    {
        RayCaster.RayCast(ref sequence, player, EndPosition, _direction.position - EndPosition, LayerMask);
    }
}
