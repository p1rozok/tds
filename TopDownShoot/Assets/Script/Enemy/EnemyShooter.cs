
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotPoint;
    public float shootInterval = 2f;
    private float shootTimer;
    private Transform player;
    public float rotationSpeed = 180f; // Speed of rotation towards the player

    void Start()
    {
        shootTimer = shootInterval;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (shotPoint == null)
        {
            Debug.LogError("ShotPoint not assigned in the inspector.");
        }

        if (bulletPrefab == null)
        {
            Debug.LogError("BulletPrefab not assigned in the inspector.");
        }
    }

    void Update()
    {
        if (player == null || shotPoint == null || bulletPrefab == null) return;

        AimAtPlayer();

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    void AimAtPlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        shotPoint.rotation = Quaternion.RotateTowards(shotPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
    }
}
