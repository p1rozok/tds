
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
        Debug.Log($"���������� �����: {points}");
        currentScore += points;
        UpdateCurrentScoreText();
    }

    void UpdateCurrentScoreText()
    {
        if (currentScoreText != null)
        {
            Debug.Log($"���������� �������� �����: {currentScore}");
            currentScoreText.text = "Score: " + currentScore.ToString();
        }
        else
        {
            Debug.LogError("CurrentScoreText �� �������� � ����������!");
        }
    }

    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            Debug.Log($"���������� ������ �������: {currentScore}");
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }

    void OnDestroy()
    {
        SaveHighScore();
    }
}
