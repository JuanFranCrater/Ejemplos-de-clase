using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAt : MonoBehaviour
{
    public GameObject targetPos;
    public float speed;
    void Update()
    {
        Vector3 desp = Vector3.MoveTowards(transform.position, targetPos.transform.position, Time.deltaTime * speed) - transform.position;
        transform.position += desp;
    }

}
