using DG.Tweening;
using UnityEngine;

public class Wall : ActionMovement
{
    protected Vector3 EndPosition { get; private set; }

    protected float Time { get; private set; }

    public override void PerformingActions(ref Sequence sequence, Transform player, Vector3 direction, Vector3 origin)
    {
        SetEndPosition(direction);
        SetTime(origin, EndPosition);
        sequence.Append(player.DOMove(EndPosition, Time).SetEase(Ease.Linear));
    }

    protected virtual Vector3 CountEndPosition(Vector3 direction)
    {
        return transform.position - direction;
    }

    protected virtual float CountTime(Vector3 origin, Vector3 endPosition)
    {
        return (endPosition - origin).magnitude / Speed;
    }

    private void SetEndPosition(Vector3 direction) => EndPosition = CountEndPosition(direction);

    private void SetTime(Vector3 origin, Vector3 endPosition) => Time = CountTime(origin, endPosition);
}
