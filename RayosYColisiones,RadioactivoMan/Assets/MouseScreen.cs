using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScreen : MonoBehaviour
{
    private bool growing =false;

    private void OnMouseDown()
    {
        growing = true;
    }
    private void OnMouseUp()
    {
        growing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (growing)
            transform.localScale += Vector3.one * Time.deltaTime;
    }
}
