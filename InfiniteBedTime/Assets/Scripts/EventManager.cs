using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;
    public GameObject howToPanel;
    private void Update()
    {
        if (deathPanel != null)
        {
            if (!deathPanel.active)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (Time.timeScale == 1)
                    {
                        pauseGame();
                    }
                    else
                    {
                        UnpauseGame();
                    }
                }
            }
        }
        else {
            if (howToPanel != null)
            {
                if (howToPanel.active)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        howToPanel.active = false;
                    }
                }
            }
        }
    }
    public void goToHowto()
    {
        howToPanel.active = true;
    }
    public void goBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void goToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void pauseGame()
    {
        pausePanel.active = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        pausePanel.active = false;
        Time.timeScale = 1;
    }
}
