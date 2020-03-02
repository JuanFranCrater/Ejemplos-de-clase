using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool gamePaused;
    public GameObject pausePanel;
    public GameObject GameOverText;

    public void SetPauseGame(bool pause)
    {
        gamePaused = pause;

        if(pause)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        if(GameOverText != null)
        {
            GameOverText.SetActive(true);
        }
    }
}
