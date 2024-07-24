
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
        // ������ ������ ������
        Debug.Log("����� ����");
        // ������� �� ����� Game Over ��� Restart
        SceneManager.LoadScene("MainMenu");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
