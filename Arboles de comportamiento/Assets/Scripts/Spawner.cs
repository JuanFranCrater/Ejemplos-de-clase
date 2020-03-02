using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public float spawnTime;

    void Start()
    {
        InvokeRepeating("SpawnObj", spawnTime, spawnTime);
    }

    public void SpawnObj()
    {
        Instantiate(objToSpawn, transform.position, transform.rotation);
    }
}
