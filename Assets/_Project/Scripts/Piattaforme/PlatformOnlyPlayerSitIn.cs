using UnityEngine;

public class PlatformOnlyPlayerSitIn : MonoBehaviour, InPlatformMover
{
    [Header("Setting Platform")]
    [SerializeField] private float _speed;
    [SerializeField] private Transform _platform;

    private Vector3 _positionStart;
    private Vector3 _positionEnd;

    private bool _moveUp;
    private bool _moveDown = true;

    private void Awake()
    {
        _positionStart = _platform.position;
        _positionEnd = new Vector3(_positionStart.x, _positionStart.y + 10f, _positionStart.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Utility._tagPlayer))
        {
            _moveUp = !_moveUp;
            _moveDown = !_moveDown;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(Utility._tagPlayer))
        {
            _moveUp = !_moveUp;
            _moveDown = !_moveDown;
        }
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if ((_moveDown) && (_platform.position != _positionStart))
        {
            _platform.position = Vector3.MoveTowards(_platform.position, _positionStart, _speed * Time.deltaTime);
        }
        else if ((_moveUp) && (_platform.position != _positionEnd))
        {
            _platform.position = Vector3.MoveTowards(_platform.position, _positionEnd, _speed * Time.deltaTime);
        }
    }
}
