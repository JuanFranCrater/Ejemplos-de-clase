using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanner : MonoBehaviour
{
    private float timeSpawns;
    public float firstTimeSpawn;
    public float timeDecrease;
    public float minTime;

    public GameObject[] obstacleTemplate;


    private void Start()
    {
        timeSpawns = firstTimeSpawn;
    }

    private void FixedUpdate()
    {
        if (timeSpawns <= 0)
        {
            int rand = Random.Range(0, obstacleTemplate.Length);
            GameObject generatedSpawn = Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
            generatedSpawn.transform.parent = transform;
            timeSpawns = firstTimeSpawn;
            if (firstTimeSpawn > minTime)
                firstTimeSpawn -= timeDecrease;
        }
        else
            timeSpawns -= Time.deltaTime;
    }


}
