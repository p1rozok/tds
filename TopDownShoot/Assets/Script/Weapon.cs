using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public GameObject weaponModel; // Модель оружия
    public GameObject bulletPrefab; // Префаб пули
    public float fireRate; // Скорость стрельбы (выстрелов в секунду)
    public float bulletSpeed; // Скорость пули
    public float damage; // Урон от пули
}
