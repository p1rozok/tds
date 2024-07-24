using UnityEngine;

public class Pistol : BaseWeapon
{
    protected override void Start()
    {
        base.Start();
        damage = 3f;
        fireRate = 2f; // 2 выстрела в секунду
    }
}
