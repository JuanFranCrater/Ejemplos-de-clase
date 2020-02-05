using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	public ObjetoDeJuego[] todosLosObjetos;
	public Balon balon;
	public GameObject gameOver;

    void Start()
    {
		ActualizaObjetos();
		balon = FindObjectOfType<Balon>();
    }

	public void ActualizaObjetos()
	{
		todosLosObjetos = FindObjectsOfType<ObjetoDeJuego>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void Marcado()
	{
		int escena = SceneManager.GetActiveScene().buildIndex + 1;
		if (escena == SceneManager.sceneCountInBuildSettings)
		{
			escena = 0;
		}
		SceneManager.LoadScene(escena);
	}

	public void FinTurno()
	{
		balon.MueveBalon();
	}

	public void ParaBalon()
	{
		balon.direccionActual = Vector2.zero;
		balon.seMueve = false;
	}

	public void CompruebaInerciaBalon()
	{
		balon.CompruebaInercia();
	}

	public void GameOver()
	{
		gameOver.SetActive(true);
	}
}
