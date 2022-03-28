using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ChildCase _childCase;

    public static event UnityAction BlockAdded;

    private void Start()
    {
        _childCase.UpdatePosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TilesAddTrigger blockEat))
        {
            _childCase.Add(blockEat.transform);
            blockEat.GetComponent<BoxCollider>().enabled = false;
            blockEat.transform.SetParent(_childCase.transform);
            _childCase.UpdatePosition();
            BlockAdded?.Invoke();

            UpdatePiratPosition();
        }

        if (other.TryGetComponent(out TilesPutTrigger blockEatEats))
        {
            blockEatEats.GetComponent<BoxCollider>().enabled = false;
            RemoveBlock(blockEatEats);
            _childCase.UpdatePosition();
            UpdatePiratPosition();
        }
    }

    private void RemoveBlock(TilesPutTrigger tilesPutTrigger)
    {
        Transform block = _childCase.Return(_childCase.transform.childCount - 1);
        block.GetComponent<BoxCollider>().enabled = false;
        block.SetPositionAndRotation(tilesPutTrigger.transform.position, tilesPutTrigger.transform.rotation);
        block.parent = tilesPutTrigger.transform;
    }

    private void UpdatePiratPosition()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out LookAt pirat))
            {
                Transform child = _childCase.Return(0);
                pirat.transform.position = child.transform.position + new Vector3(0, child.transform.localScale.y * 2, 0);
            }
        }
    }
}
