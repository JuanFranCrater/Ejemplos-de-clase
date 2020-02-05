using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
	Manager manager;
	Movible miMovible;

	public void Start()
	{
		manager = FindObjectOfType<Manager>();
		miMovible = GetComponent<Movible>();
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			manager.CompruebaInerciaBalon();
			miMovible.IntentaMover(Vector2.left, true);
			manager.FinTurno();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			manager.CompruebaInerciaBalon();
			miMovible.IntentaMover(Vector2.right, true);
			manager.FinTurno();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			manager.CompruebaInerciaBalon();
			miMovible.IntentaMover(Vector2.down, true);
			manager.FinTurno();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			manager.CompruebaInerciaBalon();
			miMovible.IntentaMover(Vector2.up, true);
			manager.FinTurno();
		}
	}

}
