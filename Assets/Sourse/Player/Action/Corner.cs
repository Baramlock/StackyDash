using DG.Tweening;
using UnityEngine;

public class Corner : Wall
{
    [SerializeField] private float _speedCoefficient = 1;
    private int _correctSign;

    protected LayerMask LayerMask { get; set; }

    public override void PerformingActions(ref Sequence sequence, Transform player, Vector3 direction, Vector3 origin)
    {
        base.PerformingActions(ref sequence, player, direction, origin);
        RayCastNewPosition(ref sequence, player, direction);
    }

    protected virtual void RayCastNewPosition(ref Sequence sequence, Transform player, Vector3 direction)
    {
        var rayDirection = new Vector3(_correctSign * direction.z, direction.y, _correctSign * direction.x);
        RayCaster.RayCast(ref sequence, player, EndPosition, rayDirection, LayerMask);
    }

    protected override Vector3 CountEndPosition(Vector3 direction) => transform.position;

    protected override float CountTime(Vector3 origin, Vector3 endPosition) => base.CountTime(origin, endPosition) * _speedCoefficient;

    private void Start()
    {
        LayerMask = PlayerMovement.LayerMask;
        _correctSign = transform.eulerAngles.y % 180 == 0 ? 1 : -1;
    }
}
