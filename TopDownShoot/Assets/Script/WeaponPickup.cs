using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public PlayerController.Weapon weaponType; // ��� ������, ������� ������������ ���� ������

    void Start()
    {
        // ������� ������ ����� 5 ������ ����� ������
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetWeapon(weaponType); // ������������� ����� ������ ������
                Destroy(gameObject); // ������� ������ ����� �������
            }
        }
    }
}
