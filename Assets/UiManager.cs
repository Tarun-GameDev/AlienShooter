using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] TextMeshProUGUI killsText;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] TextMeshProUGUI gameOverKillsText;
    int kills;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();
    }

    public void GameOver()
    {
        killsText.enabled = false;
        gameOverKillsText.text = "Kills: " + kills.ToString();
        gameOverMenu.SetActive(true);
    }

    public void Kills()
    {
        kills++;
        killsText.text = "Kills: " + kills.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
