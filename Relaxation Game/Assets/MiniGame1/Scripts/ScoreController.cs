using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int Score {  get; private set; }

    void UpdateScoreText()
    {
        scoreText.text = Score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)
    {
        Score -= amount;
        UpdateScoreText();
    }
}
