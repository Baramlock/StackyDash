using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] private float _timeToCombo;
    private int _combo;
    private Coroutine _coroutine;

    public event UnityAction<int> ComboChanged;

    public event UnityAction CombosReset;

    private void OnEnable()
    {
        Player.BlockAdded += IncreaseCombo;
    }

    private void OnDisable()
    {
        Player.BlockAdded -= IncreaseCombo;
    }

    private IEnumerator ResetCombo()
    {
        yield return new WaitForSeconds(_timeToCombo);
        _combo = 0;
        CombosReset?.Invoke();
    }

    private void IncreaseCombo()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _combo++;
        _coroutine = StartCoroutine(ResetCombo());

        ComboChanged?.Invoke(_combo);
    }
}
