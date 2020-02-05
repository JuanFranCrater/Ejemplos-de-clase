using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInicio : MonoBehaviour
{
    public string escena;
    public void IniciarJuego()
    {
        int escena = SceneManager.GetActiveScene().buildIndex + 1;
        if (escena == SceneManager.sceneCountInBuildSettings)
        {
            escena = 0;
        }
        SceneManager.LoadScene(escena);
    }
}
