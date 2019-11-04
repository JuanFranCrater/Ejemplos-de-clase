using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSpacePreGame : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            cargarJuego();
    }

    private void cargarJuego()
    {
         if(GameObject.FindGameObjectWithTag("Music") != null)
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
        SceneManager.LoadScene("Game");
    }
}
