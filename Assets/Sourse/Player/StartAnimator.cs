using DG.Tweening;
using UnityEngine;

internal class StartAnimator : MonoBehaviour
{
    [SerializeField] private Transform _transforms;
    [SerializeField] private float _time;

    private Vector3[] _points;

    public void StartAnimation(ref Sequence sequence)
    {
        _points = new Vector3[_transforms.childCount];
        for (var i = 0; i < _transforms.childCount; i++)
        {
            _points[i] = _transforms.GetChild(i).transform.position;
        }

        sequence.Append(transform.DOPath(_points, _time, PathType.CatmullRom).SetLookAt(0).SetEase(Ease.Linear));
    }
}