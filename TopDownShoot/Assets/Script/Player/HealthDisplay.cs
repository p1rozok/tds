
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    public Text healthText; // ���������� ���� ��� ��������� ������
    private PlayerHealth playerHealth; // ������ �� ��������� �������� ������

    void Start()
    {
        // ������� ������ � ��� ��������� ��������
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("Player �� ������!");
        }
    }

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "HP: " + playerHealth.GetCurrentHealth().ToString();
        }
    }
}
