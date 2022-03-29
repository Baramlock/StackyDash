using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorReplacer : MonoBehaviour
{
    [SerializeField] private Material _nextMaterial;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            transform.DOScaleY(2.5f, 0.1f);
            transform.DOScaleY(1f, 0.2f).SetDelay(0.2f);
            _meshRenderer.material = _nextMaterial;
        }
    }
}
