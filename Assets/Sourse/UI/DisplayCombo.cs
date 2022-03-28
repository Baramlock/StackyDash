using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ComboCounter))]
public class DisplayCombo : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _scale—oefficient;
    [SerializeField] private float _time;
    private ComboCounter _counter;
    private Vector3 _startScale;

    private void OnEnable()
    {
        _counter.ComboChanged += Changed;
        _counter.CombosReset += FadeCombo;
    }

    private void OnDisable()
    {
        _counter.ComboChanged -= Changed;
        _counter.CombosReset -= FadeCombo;
    }

    private void Awake()
    {
        _counter = GetComponent<ComboCounter>();
        _startScale = _text.transform.localScale;
    }

    private void Changed(int combo)
    {
        _text.text = "+" + combo.ToString();
        _text.transform.DOScale(_startScale * _scale—oefficient, _time);
        _text.transform.DOScale(_startScale, _time).SetDelay(_time);
        _text.DOFade(1, _time);
    }

    private void FadeCombo()
    {
        _text.DOFade(0, 0.3f);
    }
}
