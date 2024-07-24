using UnityEngine;

public class Rifle : BaseWeapon
{
    protected override void Start()
    {
        base.Start();
        damage = 1f;
        fireRate = 10f; // 10 выстрелов в секунду
    }
}
