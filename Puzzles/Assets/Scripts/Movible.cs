using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movible : MonoBehaviour
{
	Manager manager;

	void Start()
	{
		manager = FindObjectOfType<Manager>();
	}

	public bool IntentaMover(Vector2 direccion, bool mueveSiPuedes)
	{
		//Check si está libre
		bool libre = true;
		GameObject colision = null;
		Vector2 posicionDeseada = new Vector2(transform.position.x + direccion.x, transform.position.y + direccion.y);

		foreach (ObjetoDeJuego obj in manager.todosLosObjetos)
		{

			if (Vector3.Distance(posicionDeseada, obj.transform.position) < 0.2f)
			{
				libre = false;
				colision = obj.gameObject;
			}
		}
		//Si no está libre
		if (!libre)
		{
			//Si choco con un movible
			Movible m = colision.GetComponent<Movible>();
			if (m != null && !gameObject.CompareTag("Balon"))
			{
				//Check si se puede mover
				if (m.IntentaMover(direccion, true) == true)
				{
					libre = true;
					if (colision.CompareTag("Balon") && gameObject.GetComponent<MovimientoJugador>() != null)
					{
						Balon b = colision.GetComponent<Balon>();
						b.nuevaDir(direccion);
						b.seMueve = false;
					}
				}
				else
				{
					return false;
				}
			}
			else if (colision.CompareTag("Aro") && gameObject.CompareTag("Balon"))
			{
				manager.Marcado();
			}else if (gameObject.CompareTag("Balon") && colision.GetComponent<MovimientoJugador>() != null)
			{
				manager.ParaBalon();
			} else if (colision.CompareTag("Resistencia"))
			{
				gameObject.SetActive(false);
				libre = false;
				manager.ActualizaObjetos();
				colision.GetComponentInChildren<ParticleSystem>().Play();
				if (gameObject.CompareTag("Balon") || gameObject.GetComponent<MovimientoJugador>() != null)
				{
					manager.GameOver();
				}
			}

		}

		if (libre)
		{
			if (mueveSiPuedes)
			{
				transform.position = new Vector2(transform.position.x + direccion.x, transform.position.y + direccion.y);
			}
			return true;
		} else
		{
			return false;
		}
	}
}
