using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour, IControlable
{
    public void Action()
    {
        throw new System.NotImplementedException();
    }

    public void Down()
    {
        transform.position += Vector3.down;
    }

    public void Jump()
    {
        
    }

    public void Left()
    {
        transform.position += Vector3.left;
    }

    public void Right()
    {
        transform.position += Vector3.right;
    }

    public void Up()
    {
        transform.position += Vector3.up;
    }
}
