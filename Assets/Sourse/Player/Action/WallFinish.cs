using DG.Tweening;
using UnityEngine;

public class WallFinish : Wall
{
    [SerializeField] private float _speedCoefficient = 1;

    protected override float CountTime(Vector3 origin, Vector3 endPosition)
    {
        return base.CountTime(origin, endPosition) * _speedCoefficient;
    }
}
