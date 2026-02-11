using UnityEngine;
using UnityEngine.Events;

public class CoinMover : MonoBehaviour
{
    [Header("Setting Event Change Coin Amount")]
    [SerializeField] private UnityEvent<int> _OnChangeCoinAmount;
    private float _angleRotate = 30f;
    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, _angleRotate * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag(Utility._tagPlayer))
        {
            _OnChangeCoinAmount.Invoke(1);
            Destroy(gameObject);
        }
    }
}
