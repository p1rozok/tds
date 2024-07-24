using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public GameObject weaponModel; // ������ ������
    public GameObject bulletPrefab; // ������ ����
    public float fireRate; // �������� �������� (��������� � �������)
    public float bulletSpeed; // �������� ����
    public float damage; // ���� �� ����
}
