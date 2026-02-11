using UnityEngine;

public class YellowPath : MonoBehaviour, InPlatformMover
{
    enum Side
    {
        Left = 0,
        Right = 1,
    }

    [SerializeField] Side _side;
    [SerializeField] Vector3[] _path;
    [SerializeField] Transform _startPosition;
    private int _indexPath = 0;
    private float _speed = 5f;
    private Vector3[] _newPosition = new Vector3[4];

    private void Awake()
    {
        Vector3 firstPosition = _startPosition.position;
        for (int i = 0; i < _path.Length; i++)
        {
            Vector3 newPosition;

            newPosition = new(firstPosition.x + _path[i].x,
                              firstPosition.y + _path[i].y,
                              firstPosition.z + _path[i].z);
            _newPosition[i] = newPosition;
        }

    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (transform.position == _newPosition[_indexPath])
        {
            if (_indexPath == _path.Length - 1)
            {
                _indexPath = 0;
            }
            else
            {
                _indexPath += 1;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _newPosition[_indexPath], _speed * Time.deltaTime);
    }

}

