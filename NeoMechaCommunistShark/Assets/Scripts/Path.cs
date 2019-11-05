using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Path : MonoBehaviour
{
    public float speed;

    private Vector3 inititalPos;
    private Vector3 mediumPos;
    private Vector3 finalPos;
    private Vector3 targetPos;
    public GameObject[] listadoPositiones;
    public GameObject positionDissapear;
    private void Awake()
    {
        inititalPos = listadoPositiones[Random.Range(0, 2)].transform.position;
        mediumPos = listadoPositiones[Random.Range(2, 5)].transform.position;
        finalPos = listadoPositiones[Random.Range(6, 7)].transform.position;
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
            if (targetPos == positionDissapear.gameObject.transform.position)
            {
                Destroy(gameObject);
            }
            }
    }

    public void GoToDie()
    {
        targetPos = positionDissapear.gameObject.transform.position;
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
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
