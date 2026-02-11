using UnityEngine;

public class PlatformPath : MonoBehaviour, InPlatformMover
{
    [Header("Setting Platform")]
    [SerializeField] private Vector3[] _pathPlatform;
    [SerializeField] private float _speed;

    private int _indexPath;
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = _pathPlatform[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (transform.position == _pathPlatform[_indexPath])
        {
            if (_indexPath == _pathPlatform.Length - 1)
            {
                _indexPath = 0;
            }
            else
            {
                _indexPath += 1;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _pathPlatform[_indexPath], _speed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(Utility._tagPlayer))
        {
            collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position, 
                                                                          _pathPlatform[_indexPath],
                                                                          _speed * Time.deltaTime);
        }
    }
}
