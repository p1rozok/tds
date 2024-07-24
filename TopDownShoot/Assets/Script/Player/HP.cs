
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Логика смерти игрока
        Debug.Log("Игрок умер");
        // Переход на сцену Game Over или Restart
        SceneManager.LoadScene("MainMenu");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
