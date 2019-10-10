using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour 
{
    public Vector3 checkPointPosition;

    public void SetCheckPointPosition(Vector3 pos)
    {
        checkPointPosition = transform.position + pos;
    }

    public void LoadCheckpoint(GameObject obj)
    {
        obj.transform.position = checkPointPosition;
        if (obj.GetComponent<Rigidbody2D>() != null)
        {
            obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (obj.GetComponent<Health>() != null)
        {
            obj.GetComponent<Health>().RecoverAllHealth();
        }
    }
}
