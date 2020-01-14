using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AceleratedBody : MonoBehaviour, IControlable
{
    public float power = 10f;

    Vector2 acceleration;

    Vector2 speed;
    private void Update()
    {
        speed += acceleration * Time.deltaTime;

        transform.position += (Vector3)speed * Time.deltaTime;
        acceleration = Vector2.zero;
    }
    public void Down()
    {
        acceleration = power * Vector2.down;
    }

    public void Left()
    {
        acceleration = power * Vector2.left;
    }

    public void Right()
    {
        acceleration = power * Vector2.right;
    }

    public void Up()
    {
        acceleration = power * Vector2.up;
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
