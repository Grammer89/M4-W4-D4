using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Setting Player")]
    [SerializeField] float _speed;
    [SerializeField] float _forceUp;
    [SerializeField] float _rotationSpeed;
    [SerializeField] Rigidbody _rb;

    MenageGround _ground;
    private Vector3 _dir;
    private Vector3 _dirMouse;

    // Start is called before the first frame update
    void Awake()
    {
        _ground = new MenageGround();
    }

    // Update is called once per frame
    void Update()
    {

        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");
        if (_dir.magnitude > 1)
        {
            _dir.x = _dir.x / _dir.sqrMagnitude;
            _dir.z = _dir.z / _dir.sqrMagnitude;
        }
        _dirMouse.x = Input.GetAxis("Mouse X");
        _dirMouse.y = -Input.GetAxis("Mouse Y");

        if (Input.GetButtonDown("Jump") && (_ground.IsGrounded))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {

        //Gestione Movimento
        _rb.MovePosition(_rb.position + transform.forward * (_dir.z * Time.deltaTime * _speed));

        //Gestione Rotazione
        Vector3 deltaRotEuler = Vector3.up * (_dir.x * _rotationSpeed * Time.deltaTime);
        Quaternion deltaRotQuaternion = Quaternion.Euler(deltaRotEuler);
        _rb.rotation = (_rb.rotation * deltaRotQuaternion); //Sommo la rotazione del RB + il delta


    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _forceUp, ForceMode.Impulse);
    }
    public void Move(float speed)
    {
        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }

}
