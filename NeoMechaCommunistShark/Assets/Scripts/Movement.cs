using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 15f;


    void FixedUpdate()
    {
        if (MouseScreenCheck())
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
    public bool MouseScreenCheck()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float screenX = Screen.width;
        float screenY = Screen.height;

        return (!(mouseX < 0 || mouseX > screenX || mouseY < 0 || mouseY > screenY));
          
    }
}
