
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    public Text healthText; // Перетащите сюда ваш текстовый объект
    private PlayerHealth playerHealth; // Ссылка на компонент здоровья игрока

    void Start()
    {
        // Находим игрока и его компонент здоровья
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("Player не найден!");
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
