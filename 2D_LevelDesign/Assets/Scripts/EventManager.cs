using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public void goBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void goToGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void goToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void goToWin()
    {
        SceneManager.LoadScene("Win");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
