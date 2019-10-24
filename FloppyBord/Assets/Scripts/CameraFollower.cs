using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float offset;
	
	void Update ()
    {
        if(target != null)
            transform.position = new Vector3(target.position.x + offset, transform.position.y, transform.position.z);
	}
}
