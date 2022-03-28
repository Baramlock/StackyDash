using UnityEngine;

public class LookAt : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
