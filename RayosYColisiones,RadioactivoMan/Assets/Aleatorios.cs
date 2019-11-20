using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleatorios : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Random.value * 6);
        Debug.Log(Random.Range(0.5f, 2.5f));
        Debug.Log(Random.Range(0, 4));
        Debug.Log(Random.insideUnitSphere);
    }


}
