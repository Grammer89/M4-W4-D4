using UnityEngine;

public class PlatformRotation : MonoBehaviour, InPlatformMover
{
    [Header("Setting Platform")]
    [SerializeField] private float _speed;

    // Update is called once per frame


    private void Update()
    {
        Move();
    }
  
    public void Move()
    {
        transform.RotateAround(transform.position, Vector3.up, _speed * Time.deltaTime);
    }
}
