using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] obstacle; 

    private void Start()
    {
        int rand = Random.Range(0, obstacle.Length);
        GameObject obstacleRnd =  Instantiate(obstacle[rand], transform.position, Quaternion.identity);
        obstacleRnd.GetComponentInChildren<Transform>().Rotate(Vector3.up, Random.Range(0, 359));
        obstacleRnd.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}
