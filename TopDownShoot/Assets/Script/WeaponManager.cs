/*using UnityEngine;



public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon; // ������� ������
    public List<Weapon> availableWeapons; // ������ ��������� ������

    private GameObject currentWeaponModel;

    void Start()
    {
        if (currentWeapon != null)
        {
            EquipWeapon(currentWeapon);
        }
    }

    // ����� ��� ����� ������
    public void EquipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;

        // ������� ������ ������ ������, ���� ��� ����
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }

        // ������� � ������������� ����� ������ ������
        if (currentWeapon.weaponModel != null)
        {
            currentWeaponModel = Instantiate(currentWeapon.weaponModel, transform.position, Quaternion.identity, transform);
        }

        // ����������� ��������� ��������
        GunController gunController = GetComponent<GunController>();
        if (gunController != null)
        {
            gunController.bulletPrefab = currentWeapon.bulletPrefab;
            gunController.startTimeBtwShots = 1f / currentWeapon.fireRate;
        }

        Debug.Log("������ �����������: " + newWeapon.weaponName);
    }

    // ����� ��� ���������� ������ ������ � ���������
    public void AddWeapon(Weapon weapon)
    {
        if (!availableWeapons.Contains(weapon))
        {
            availableWeapons.Add(weapon);
        }
    }
}
*/