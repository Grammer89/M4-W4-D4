using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Setting Info Bullet")]
    [SerializeField] float _velocityBullet;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _timeLifeBullet;

    private void Start()
    {
        _audioSource.Play();
    }
    public void MoveBullet(Vector3 target)
    {
        
        _rb.velocity = target * _velocityBullet;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Utility._tagPlayer))
        {
            other.gameObject.GetComponent<LifeController>().TakeDamage(10);
            Destroy(gameObject , 2f);
        }
        else
        {
            Destroy(gameObject, _timeLifeBullet);
        }
    }
}
