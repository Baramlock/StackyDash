using UnityEngine;

public class LookAtNorth : MonoBehaviour
{
    [SerializeField] private bool _setPosition = false;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
        if (_setPosition)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
