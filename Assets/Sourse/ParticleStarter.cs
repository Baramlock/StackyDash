using System.Collections.Generic;
using UnityEngine;

public class ParticleStarter : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            foreach (var particle in _particleSystem)
            {
                particle.Play();
            }
        }
    }
}
