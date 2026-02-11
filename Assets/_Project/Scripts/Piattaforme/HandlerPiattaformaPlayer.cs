using UnityEngine;

public class HandlerPiattaformaPlayer : MonoBehaviour
{
    [SerializeField] Transform _platform;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag Object:" + other.gameObject.tag);
        if (other.gameObject.CompareTag(Utility._tagPlayer))
        {
            Debug.Log("Set Parent con: " + gameObject.name);
            other.gameObject.transform.parent = _platform;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Utility._tagPlayer))
        {
            other.gameObject.transform.SetParent(null);

        }
    }

}
