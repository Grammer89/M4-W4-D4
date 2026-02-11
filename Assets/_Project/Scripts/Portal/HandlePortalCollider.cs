using UnityEngine;
using UnityEngine.Events;

public class HandlePortalCollider : MonoBehaviour
{
    [Header("Setting Portal Info")]
    [SerializeField] UnityEvent _OnEventWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Utility._tagPlayer))
        {
            Debug.Log("Il portale collide");
            _OnEventWin.Invoke();
        }
    }

}
