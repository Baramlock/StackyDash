using UnityEngine;
using UnityEngine.Events;

public class ChildCase : MonoBehaviour
{
    [SerializeField] private float _correctDistant;

    public int ChildCount => transform.childCount;

    public void Add(Transform transform)
    {
        transform.parent = transform;
    }

    public Transform Return(int index)
    {
        return transform.GetChild(index);
    }

    public bool CheckAvailable()
    {
        return transform.childCount > 0;
    }

    public void UpdatePosition()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(transform.childCount - i - 1).transform.localPosition
                = new Vector3(0, i * transform.GetChild(i).transform.localScale.y * _correctDistant, 0);
        }
    }
}
