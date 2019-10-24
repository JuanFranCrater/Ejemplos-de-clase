using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
    }
}
