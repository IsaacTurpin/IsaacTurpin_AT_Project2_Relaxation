using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip goodSound;
    [SerializeField] AudioClip badSound;
    public int Score {  get; private set; }

    void UpdateScoreText()
    {
        scoreText.text = Score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
        audioSource.clip = goodSound;
        audioSource.Play();
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)
    {
        Score -= amount;
        audioSource.clip = badSound;
        audioSource.Play();
        UpdateScoreText();
    }
}
