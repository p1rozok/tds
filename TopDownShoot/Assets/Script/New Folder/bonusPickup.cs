
using UnityEngine;

public class BonusPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // «десь можно добавить логику дл€ применени€ бонуса к игроку
            ApplyBonus(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyBonus(GameObject player)
    {
        // Ћогика применени€ бонуса
        Debug.Log("Ѕонус подобран: " + gameObject.name);
        // ѕример: можно увеличить скорость игрока на 10 секунд
        // player.GetComponent<PlayerController>().IncreaseSpeed(10f);
    }
}
