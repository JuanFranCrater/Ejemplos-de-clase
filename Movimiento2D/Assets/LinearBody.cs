using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBody : MonoBehaviour, IControlable
{
    Vector2 speed;
    public float power = 10f;

    private void Update()
    {
        transform.position += (Vector3)speed * Time.deltaTime;
    }
    public void Down()
    {
        speed = Vector3.down*power;
    }

    public void Left()
    {
        speed = Vector3.left * power;
    }

    public void Right()
    {
        speed = Vector3.right * power;
    }

    public void Up()
    {
        speed = Vector3.up * power;
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void Action()
    {
        throw new System.NotImplementedException();
    }
}
