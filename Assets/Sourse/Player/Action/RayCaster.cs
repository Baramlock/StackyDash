using DG.Tweening;
using UnityEngine;

public static class RayCaster
{
    public static void RayCast(ref Sequence sequence, Transform player, Vector3 origin, Vector3 direction, LayerMask layerMask)
    {
        var ray = new Ray(origin, direction);
        Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, layerMask);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.TryGetComponent(out ActionMovement action))
            {
                action.PerformingActions(ref sequence, player, direction, origin);
            }
        }
    }
}