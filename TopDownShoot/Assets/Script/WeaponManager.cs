/*using UnityEngine;



public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon; // Текущее оружие
    public List<Weapon> availableWeapons; // Список доступных оружий

    private GameObject currentWeaponModel;

    void Start()
    {
        if (currentWeapon != null)
        {
            EquipWeapon(currentWeapon);
        }
    }

    // Метод для смены оружия
    public void EquipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;

        // Удаляем старую модель оружия, если она есть
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }

        // Создаем и устанавливаем новую модель оружия
        if (currentWeapon.weaponModel != null)
        {
            currentWeaponModel = Instantiate(currentWeapon.weaponModel, transform.position, Quaternion.identity, transform);
        }

        // Настраиваем параметры стрельбы
        GunController gunController = GetComponent<GunController>();
        if (gunController != null)
        {
            gunController.bulletPrefab = currentWeapon.bulletPrefab;
            gunController.startTimeBtwShots = 1f / currentWeapon.fireRate;
        }

        Debug.Log("Оружие экипировано: " + newWeapon.weaponName);
    }

    // Метод для добавления нового оружия в инвентарь
    public void AddWeapon(Weapon weapon)
    {
        if (!availableWeapons.Contains(weapon))
        {
            availableWeapons.Add(weapon);
        }
    }
}
*/