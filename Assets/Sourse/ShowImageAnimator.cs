using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageAnimator : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _delay;
    [SerializeField] private float _time;
    [SerializeField] private float _count;

    private void Start()
    {
        StartCoroutine(nameof(Animation));
    }

    private IEnumerator Animation()
    {
        yield return new WaitForSeconds(_delay);
        Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < _count; i++)
        {
            sequence.Append(_image.DOFade(1, _time / 2)).SetEase(Ease.Linear);
            sequence.Append(_image.DOFade(0, _time / 2)).SetEase(Ease.Linear);
        }
    }
}
