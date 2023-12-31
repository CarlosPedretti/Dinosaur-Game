using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text highestScoreText;

    private int score;
    private int highestScore;
    public float timer;
    private float scrollSpeed;
    public float initialScrollSpeed = 8f;

    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        highestScore = PlayerPrefs.GetInt("HighScore");

    }

    void Update()
    {
        UpdateScore();

        UpdateSpeed();
    }


    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    void UpdateScore()
    {
        int scorePerSeconds = 10;
        timer += Time.deltaTime;
        score = (int)(timer * scorePerSeconds);
        ScoreText.text = string.Format("{0:00000}", score);
        highestScoreText.text = string.Format("{0:00000}", highestScore);

        if (score > highestScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 10f;
        scrollSpeed = initialScrollSpeed + timer / speedDivider;
    }

}