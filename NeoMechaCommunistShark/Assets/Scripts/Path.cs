using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public float speed;

    private Vector3 inititalPos;
    private Vector3 mediumPos;
    private Vector3 finalPos;
    private Vector3 targetPos;
    public GameObject[] listadoPositiones;

    private void Awake()
    {
        inititalPos = listadoPositiones[0].transform.position;
        mediumPos = listadoPositiones[1].transform.position;
        targetPos = listadoPositiones[2].transform.position;
    }
    void Start()
    {
        targetPos = inititalPos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        col.gameObject.GetComponent<Health>().TakeDamage(1);
    }

    void Update()
    {
            Vector3 desp = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed) - transform.position;
            transform.position += desp;
            if (transform.position == targetPos)
            {
                ChangeTargetPos();
            }
    }

    private void ChangeTargetPos()
    {
        if (targetPos == inititalPos)
        {
            targetPos = mediumPos;
        } else if (targetPos == mediumPos)
        {
            targetPos = finalPos;
        }
        else {
            targetPos = inititalPos;
        }

    }
}
