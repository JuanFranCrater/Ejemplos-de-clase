using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public float time;
    public GameObject[] tankes;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(crearTanques());    
    }
    bool vuelta = false;
    IEnumerator crearTanques()
    {
        while (true)
        {
            Instantiate(tankes[vuelta ? 0 : 1],transform);
            yield return new WaitForSeconds(time);
            vuelta = !vuelta;
        }
    }
}
