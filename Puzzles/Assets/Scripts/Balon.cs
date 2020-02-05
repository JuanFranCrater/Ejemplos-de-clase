using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balon : MonoBehaviour
{
	Movible m;
	public Vector2 direccionActual = Vector2.zero;
	public bool seMueve = false;
	public ParticleSystem golpeVFX;

	public void Start()
	{
		m = GetComponent<Movible>();
	}

	public void MueveBalon()
	{
		if (direccionActual != Vector2.zero)
		{
			if (seMueve == true)
			{
				if (m.IntentaMover(direccionActual, true) == false)
				{
					//golpeVFX.Play();
					nuevaDir (direccionActual * -1);
					if (m.IntentaMover(direccionActual, true) == false)
					{
						nuevaDir (Vector2.zero);
						seMueve = false;
					}
				}
				CompruebaChoque();
			} else
			{
				seMueve = true;
			}
		}
	}

	public void nuevaDir(Vector2 dir)
	{
		direccionActual = dir;
	}

	public void CompruebaChoque()
	{
		if (m.IntentaMover(direccionActual, false) == false && direccionActual != Vector2.zero)
		{
			golpeVFX.Play();
		}
	}

	public void CompruebaInercia()
	{
		m.IntentaMover(direccionActual, false);
	}
}
