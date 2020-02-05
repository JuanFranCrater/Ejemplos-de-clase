using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjetoDeJuego : MonoBehaviour
{
	public string tipoDeObjeto;
	//public GameObject gameObject;
#if UNITY_EDITOR
	void OnDrawGizmos()
		{
			transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		}


	void Start()
	{
		if (tipoDeObjeto != "")
		{
			transform.parent = GameObject.Find(tipoDeObjeto).transform;
		}
		//gameObject = GetComponent<Transform>().gameObject;
	}
#endif


	void Update()
	{
	}
}
