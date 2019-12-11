using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos : MonoBehaviour
{
    public UnityEvent onClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick.Invoke();
        }
    }

    public void SayHello()
    {
        Debug.Log("Hello");
    }
}
