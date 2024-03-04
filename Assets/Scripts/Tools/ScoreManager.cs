using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public static event Action OnHighScoreReady;

    public int score;
    public int hightScore;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        score = 0;
        hightScore = GetHighScore();
        OnHighScoreReady?.Invoke();
    }

    public int GetHighScore()
    {
        if(PlayerPrefs.HasKey("HightScore"))
            hightScore = PlayerPrefs.GetInt("HightScore");
        else
            hightScore = 0;
            
        return hightScore;
    }

    public void AddScore()
    {
        score++;

        UIController.Instance.UpdateScore(score);
        AudioManager.Instance.PlaySound(AudioType.Point, AudioSourceType.Game);

        if(score > hightScore)
        {
            hightScore = score;
            PlayerPrefs.SetInt("HightScore", hightScore);
        }

        StarManager.Instance.UpdateStar(hightScore);
    }
}
