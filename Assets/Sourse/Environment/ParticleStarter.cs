using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleStarter : ActinToTrigger
{
    private ParticleSystem _particleSystem;

    protected override void Action()
    {
        _particleSystem.Play();
    }

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
}
