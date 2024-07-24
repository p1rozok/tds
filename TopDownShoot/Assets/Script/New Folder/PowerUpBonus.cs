
using UnityEngine;

public class PowerUpBonus : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, Invincibility }
    public PowerUpType powerUpType;
    public float duration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUpBonus(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUpBonus(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            switch (powerUpType)
            {
                case PowerUpType.SpeedBoost:
                    playerController.StartCoroutine(playerController.SpeedBoost(duration));
                    break;
                case PowerUpType.Invincibility:
                    playerController.StartCoroutine(playerController.Invincibility(duration));
                    break;
            }
            Debug.Log("Power-up bonus applied: " + powerUpType);
        }
    }
}
