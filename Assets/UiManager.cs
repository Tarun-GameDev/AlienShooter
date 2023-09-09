using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject NewHighScoreTitle;
    int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        highScoreText.text = "HighScore: " +  PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();
    }

    public void GameOver()
    {
        scoreText.enabled = false;
        gameOverScoreText.text = "Kills: " + score.ToString();
        int _highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > _highScore)
        {
            NewHighScoreTitle.SetActive(true);
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        gameOverMenu.SetActive(true);
    }

    public void Kills()
    {
        score++;
        scoreText.text = "Kills: " + score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
