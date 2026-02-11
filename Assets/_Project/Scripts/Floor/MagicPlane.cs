using UnityEngine;

public class MagicPlane : MonoBehaviour
{
    [SerializeField] Transform _tranformCoin;
    [SerializeField] MeshCollider _colliderPlane;
    // Start is called before the first frame update

    private void Awake()
    {
        _colliderPlane = GetComponent<MeshCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Utility._tagPlayer))
        {
            Vector3 newPositionPlayer = new Vector3(_tranformCoin.position.x, _tranformCoin.position.y + 20f, _tranformCoin.position.z);
            other.transform.position = newPositionPlayer;
            _colliderPlane.isTrigger = false;

        }
    }
}
