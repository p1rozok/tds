using UnityEngine;

public class WeaponSpawnerController : MonoBehaviour
{
    private GunController gunController;

    void Awake()
    {
        gunController = GetComponent<GunController>();
        if (gunController != null)
        {
            gunController.enabled = false; // Отключаем компонент стрельбы
        }
    }
}
