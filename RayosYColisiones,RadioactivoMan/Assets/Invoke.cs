using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseScale", 2f, 0.5f);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            CancelInvoke("IncreaseScale");
    }
}
