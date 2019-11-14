using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;
    private bool _paused;
    public AudioSource audio;

    private void Start()
    {
        SetPauseGame(false);
    }

    public void SetPauseGame(bool pause)
    {
        if (!deathPanel.active)
        {
            _paused = pause;
            Time.timeScale = pause ? 0 : 1;
            pausePanel.SetActive(pause);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPauseGame(!_paused);
    }

    public void SetGameOver(bool gameOver)
    {
        Time.timeScale = gameOver ? 0 : 1;
        deathPanel.SetActive(gameOver);
        audio.Stop();

    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}

