
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    private float timeBtwShots;

    protected virtual void Start()
    {
        timeBtwShots = 0f;
    }

    protected virtual void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                timeBtwShots = 1 / fireRate;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public virtual void Shoot()
    {
        if (bulletPrefab != null && shotPoint != null)
        {
            Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        }
        else
        {
            Debug.LogError("BulletPrefab или ShotPoint не назначены.");
        }
    }
}
