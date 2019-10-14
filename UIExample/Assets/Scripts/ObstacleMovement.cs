using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool activated = true;
    public float speed;
    public Vector3 startPosition, finalPosition;
    private Vector3 targetPos;

    void Awake()
    {
        targetPos = startPosition;
    }

    void Update()
    {
        if (transform.position == startPosition)
            targetPos = finalPosition;
        if (transform.position == finalPosition)
            targetPos = startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
	
    [ContextMenu("Set Start Position")]
    public void SetStartPosition()
    {
        startPosition = transform.position;
    }

    [ContextMenu("Set Final Position")]
    public void SetFinalPosition()
    {
        finalPosition = transform.position;
    }
}
