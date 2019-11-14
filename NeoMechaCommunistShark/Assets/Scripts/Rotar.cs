using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    bool up = false;
    void FixedUpdate()
    {

        transform.Rotate(Vector3.forward * (up ? 0.9f : -0.9f));
        if (transform.rotation.z >= -0.30 && !true)
        {
            up = true;
        }
        else if(transform.rotation.z <= 0.30 && true)
        {
            up = false;
        }
    }
}
