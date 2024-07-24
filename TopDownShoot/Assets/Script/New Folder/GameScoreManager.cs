
using UnityEngine;
using UnityEngine.UI;


public class GameScoreManager : MonoBehaviour
{
    public Text currentScoreText;
    private int currentScore = 0;

    void Start()
    {
        UpdateCurrentScoreText();
    }

    public void AddScore(int points)
    {
        Debug.Log($"Добавление очков: {points}");
        currentScore += points;
        UpdateCurrentScoreText();
    }

    void UpdateCurrentScoreText()
    {
        if (currentScoreText != null)
        {
            Debug.Log($"Обновление текущего счета: {currentScore}");
            currentScoreText.text = "Score: " + currentScore.ToString();
        }
        else
        {
            Debug.LogError("CurrentScoreText не назначен в инспекторе!");
        }
    }

    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            Debug.Log($"Сохранение нового рекорда: {currentScore}");
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }

    void OnDestroy()
    {
        SaveHighScore();
    }
}
