using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaDetection : MonoBehaviour
{
    public string objTag;
    public UnityEvent onArea;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == objTag)
        {
            onArea.Invoke();
        }
    }
}
