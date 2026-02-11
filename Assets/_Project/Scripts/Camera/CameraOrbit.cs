using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [Header("Setting Camera")]
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 2, -5);
    [SerializeField] float mouseSensivity = 3f;
    [SerializeField] float bottomClamp = -30f;
    [SerializeField] float topClamp = 60f;

    float yaw;
    float pitch;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensivity;
        pitch = Mathf.Clamp(pitch, bottomClamp, topClamp);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desideredPosition = target.position + rotation * offset;

        Vector3 lookAt = target.position + Vector3.up * 2;
        Quaternion lookRotation = Quaternion.LookRotation(lookAt - desideredPosition);
        transform.SetPositionAndRotation(desideredPosition, lookRotation);
    }
}
