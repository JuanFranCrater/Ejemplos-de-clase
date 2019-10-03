using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn; // Objeto a instanciar
    public float spawnTime; // Tiempo entre instanciaciones
	private float _timer;

    void Update()
    {
		_timer -= Time.deltaTime;
		if(_timer <= 0)
		{
			SpawnObj();
			_timer = spawnTime;
		}
    }

    public void SpawnObj()
    {
        Instantiate(objToSpawn, transform.position, transform.rotation); // Crea el objeto en la posición y con la rotación que tenga el objeto que contiene el script.
    }
}
