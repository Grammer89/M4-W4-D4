using UnityEngine;

public class PlatformMove_A_B : MonoBehaviour, InPlatformMover
{

    [Header("Setting Platform")]
    [SerializeField] private float _speed;

    private Vector3 _positionStart;
    private Vector3 _positionEnd;

    private bool _moveUp = true;
    private bool _moveDown;

    private void Awake()
    {
        _positionStart = gameObject.transform.position;
        _positionEnd = new Vector3(_positionStart.x, _positionStart.y + 10f, _positionStart.z);
    }

    private void Update()
    {
        if (transform.position.y == _positionEnd.y
            || transform.position.y == _positionStart.y)
        {
            _moveUp = !_moveUp;
            _moveDown = !_moveDown;

        }
        Move();
    }
  
    public void Move()
    {
        if (_moveDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionStart, _speed * Time.deltaTime);
        }
        else if (_moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positionEnd, _speed * Time.deltaTime);
        }
    }
}
