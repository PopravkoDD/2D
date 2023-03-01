using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private Transform _teleportPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var deltaPosition = other.transform.position - transform.position;
            other.transform.position = _teleportPosition.position + deltaPosition;
        }
    }
}
