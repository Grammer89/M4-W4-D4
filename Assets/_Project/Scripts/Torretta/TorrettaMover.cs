using UnityEngine;

public class TorrettaMover : MonoBehaviour
{
    [Header("Setting Torretta")]
    [SerializeField] float _angle;
    [SerializeField] float _velAngolare;

    Vector3 _rotationMax;
    Vector3 _rotationMin;
    bool _back;

    // Start is called before the first frame update
    void Awake()
    {

        _rotationMax = transform.localEulerAngles;
        _rotationMax.y += _angle;

        _rotationMin = transform.localEulerAngles;
        _rotationMin.y -= _angle;

    }


    private void Update()
    {
        RotationTorretta();
    }



    public void RotationTorretta()
    {
        if ((int)transform.localEulerAngles.y >= (int)_rotationMax.y)
        {
            _back = true;
        }
        else if ((int)transform.localEulerAngles.y <= (int)_rotationMin.y)
        {
            _back = false;
        }

        if (!_back)
        {

            Quaternion rotation = Quaternion.Euler(_rotationMax);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _velAngolare * Time.deltaTime);


        }
        else
        {
            Quaternion rotation = Quaternion.Euler(_rotationMin);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _velAngolare * Time.deltaTime);


        }
    }


}
