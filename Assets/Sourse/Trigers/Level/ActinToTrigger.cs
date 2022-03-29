using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ActinToTrigger : MonoBehaviour
{
    [SerializeField] private LevelTrigger _levelTrigger;

    protected virtual void CheckTrigger(Collider collider)
    {
        if (collider.TryGetComponent(out Player _))
        {
            Action();
        }
    }

    protected abstract void Action();

    private void OnEnable()
    {
        _levelTrigger.Enter += CheckTrigger;
    }

    private void OnDisable()
    {
        _levelTrigger.Enter -= CheckTrigger;
    }
}
