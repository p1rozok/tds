using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public PlayerController.Weapon weaponType; // Тип оружия, которое представляет этот объект

    void Start()
    {
        // Удаляем объект через 5 секунд после спавна
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetWeapon(weaponType); // Устанавливаем новое оружие игроку
                Destroy(gameObject); // Удаляем объект после подбора
            }
        }
    }
}
