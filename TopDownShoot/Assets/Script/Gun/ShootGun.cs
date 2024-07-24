
using UnityEngine;

public class Shotgun : BaseWeapon
{
    public int pelletCount = 5;
    public float spreadAngle = 10f;

    protected override void Start()
    {
        base.Start();
        damage = 2f;
        fireRate = 1.5f; // 1.5 выстрела в секунду
    }

    public override void Shoot()
    {
        if (bulletPrefab != null && shotPoint != null)
        {
            for (int i = 0; i < pelletCount; i++)
            {
                float angle = spreadAngle * (i - (pelletCount - 1) / 2f);
                Quaternion rotation = Quaternion.Euler(0, 0, shotPoint.eulerAngles.z + angle);
                Instantiate(bulletPrefab, shotPoint.position, rotation);
            }
        }
        else
        {
            Debug.LogError("BulletPrefab или ShotPoint не назначены.");
        }
    }
}
