
using UnityEngine;

public class BonusPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ����� ����� �������� ������ ��� ���������� ������ � ������
            ApplyBonus(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyBonus(GameObject player)
    {
        // ������ ���������� ������
        Debug.Log("����� ��������: " + gameObject.name);
        // ������: ����� ��������� �������� ������ �� 10 ������
        // player.GetComponent<PlayerController>().IncreaseSpeed(10f);
    }
}
