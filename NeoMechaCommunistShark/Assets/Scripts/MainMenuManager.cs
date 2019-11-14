using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            cerrar();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("PreGame");
    }
    public void LoadInstScene()
    {
        SceneManager.LoadScene("Inst");
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
   

    public void cerrar()
    {
        Application.Quit();
    }
}
