using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextSeacrher : ActinToTrigger
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _timeToFade;

    protected override void Action()
    {
        _text.DOFade(1, 0.01f);
        _text.DOFade(0, 0.2f).SetDelay(_timeToFade);
    }
}