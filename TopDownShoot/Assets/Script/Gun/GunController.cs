
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float offset;
    public GameObject pistolBulletPrefab;
    public GameObject rifleBulletPrefab;
    public GameObject shotgunBulletPrefab;
    public GameObject grenadeLauncherBulletPrefab;
    public Transform shotPoint;
    public Joystick joystick;
    public PlayerController player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private bool facingRight = true;

    public float bulletSpeed = 10f; // Скорость пули

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            if (player == null)
            {
                Debug.LogError("Player не назначен и не найден по тегу.");
            }
        }

        if (joystick == null)
        {
            Debug.LogError("Joystick не назначен в инспекторе.");
        }

        if (shotPoint == null)
        {
            Debug.LogError("ShotPoint не назначен в инспекторе.");
        }

        if (player.controlType == PlayerController.ControlType.PC)
        {
            joystick.gameObject.SetActive(false); // Скрываем джойстик, если выбран ПК
        }
    }

    void Update()
    {
        if (player == null || shotPoint == null)
        {
            return;
        }

        Vector3 difference;
        if (player.controlType == PlayerController.ControlType.PC)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.z = 0; // Убираем компонент z
        }
        else
        {
            difference = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        }

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (difference != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if ((difference.x > 0 && !facingRight) || (difference.x < 0 && facingRight))
            {
                Flip();
            }
        }

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) || (joystick.Horizontal != 0 || joystick.Vertical != 0))
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (shotPoint == null)
        {
            Debug.LogError("ShotPoint не назначен.");
            return;
        }

        GameObject bulletPrefab = null;

        switch (player.currentWeapon)
        {
            case PlayerController.Weapon.Pistol:
                bulletPrefab = pistolBulletPrefab;
                break;
            case PlayerController.Weapon.Rifle:
                bulletPrefab = rifleBulletPrefab;
                break;
            case PlayerController.Weapon.Shotgun:
                bulletPrefab = shotgunBulletPrefab;
                break;
            case PlayerController.Weapon.GrenadeLauncher:
                bulletPrefab = grenadeLauncherBulletPrefab;
                break;
        }

        if (bulletPrefab != null)
        {
            GameObject newBullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * bulletSpeed;
            }
        }
        else
        {
            Debug.LogError("BulletPrefab не назначен для текущего оружия.");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.y *= 1;  // Изменяем ось Y для переворота
        transform.localScale = scaler;

        player.Flip(); // Поворачиваем персонажа
    }

    public void SetWeapon(PlayerController.Weapon weapon)
    {
        switch (weapon)
        {
            case PlayerController.Weapon.Pistol:
                startTimeBtwShots = 0.5f;
                bulletSpeed = 10f;
                break;
            case PlayerController.Weapon.Rifle:
                startTimeBtwShots = 0.1f;
                bulletSpeed = 15f;
                break;
            case PlayerController.Weapon.Shotgun:
                startTimeBtwShots = 1f;
                bulletSpeed = 8f;
                break;
            case PlayerController.Weapon.GrenadeLauncher:
                startTimeBtwShots = 1.5f;
                bulletSpeed = 5f;
                break;
        }
    }
}
