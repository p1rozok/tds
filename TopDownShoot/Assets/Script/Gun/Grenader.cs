
using UnityEngine;

public class GrenadeLauncher : BaseWeapon
{
    protected override void Start()
    {
        base.Start();
        damage = 10f;
        fireRate = 0.66f; // 0.66 �������� � �������
    }

    public override void Shoot()
    {
        if (bulletPrefab != null && shotPoint != null)
        {
            GameObject grenade = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
            // ������ ��� �������: ��������, ��������� ������� ��� ������
        }
        else
        {
            Debug.LogError("BulletPrefab ��� ShotPoint �� ���������.");
        }
    }
}
