
using UnityEngine;

public class WeaponBonus : MonoBehaviour
{
    public enum WeaponType { Pistol, Rifle, Shotgun, GrenadeLauncher }
    public WeaponType weaponType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyWeaponBonus(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyWeaponBonus(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            switch (weaponType)
            {
                case WeaponType.Pistol:
                    playerController.SetWeapon(PlayerController.Weapon.Pistol);
                    break;
                case WeaponType.Rifle:
                    playerController.SetWeapon(PlayerController.Weapon.Rifle);
                    break;
                case WeaponType.Shotgun:
                    playerController.SetWeapon(PlayerController.Weapon.Shotgun);
                    break;
                case WeaponType.GrenadeLauncher:
                    playerController.SetWeapon(PlayerController.Weapon.GrenadeLauncher);
                    break;
            }
            Debug.Log("Weapon bonus applied: " + weaponType);
        }
    }
}
