using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool _paused;

    private void Start()
    {
        SetPauseGame(false);
    }

    public void SetPauseGame(bool pause)
    {
        _paused = pause;
        Time.timeScale = pause ? 0 : 1;
        pausePanel.SetActive(pause);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SetPauseGame(!_paused);
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
