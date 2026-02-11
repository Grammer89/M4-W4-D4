using UnityEngine;

public class GunTorretta : MonoBehaviour
{
    [Header("Setting Raycast")]
    [SerializeField] LayerMask _layerMask;
    [SerializeField] float _maxDistance;
    [Header("Bullet")]
    [SerializeField] GameObject _bullet;
    [SerializeField] float _fireRate = 0.5f;

    float _timeToWaitResidue;
    void Update()
    {
        _timeToWaitResidue += Time.deltaTime;
        CheckAndShoot();
    }

    public void CheckAndShoot()
    {

        Debug.DrawRay(transform.position, transform.forward * _maxDistance, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance, _layerMask))
        {
            if (CanIShoot())
            {
                Shoot(hit);
            }
        }
    }
    public bool CanIShoot()
    {
        if (_timeToWaitResidue > _fireRate)
        {
            _timeToWaitResidue = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Shoot(RaycastHit hit)
    {
        GameObject bullet = Instantiate(_bullet);
        bullet.transform.position = gameObject.transform.position;
        Vector3 direction = hit.point - transform.position;
        //Vector3 direction = hit.point;
        bullet.GetComponent<Bullet>().MoveBullet(direction);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.forward * 20f);
    //}
}
