using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJumpBody : MonoBehaviour, IControlable
{

    public float dragFactor = 0.001f;
    protected Vector2 acceleration;
    private enum direction { Up = 1, Down = 2, Right = 4, Left = 8 };
    private direction actualDirection;
    public float colliderHeight = 0.5f;
    protected Vector2 speed;
    protected bool groundContact;
    protected bool rigthContact;
    protected bool leftContact;
    protected bool ceilingContact;

    private void Start()
    {
        actualDirection = direction.Down;
    }

    private void FixedUpdate()
    {
        AddGravity();
        ResolveCollison();

    }

    public void Jump()
    {
        switch (actualDirection)
        {
            case direction.Up:
                acceleration += Vector2.down;
                break;
            case direction.Down:
                acceleration += Vector2.up;
                break;
            case direction.Right:
                acceleration += Vector2.left;
                break;
            case direction.Left:
                acceleration += Vector2.right;
                break;
        }
    }
    public void Action()
    {
        //Viaja en la direccion seleccionada por el jugador
    }
    public void Down()
    {
        //Mira abajo
    }


    public void Left()
    {
        //Mira izquierda
    }

    public void Right()
    {

        //Mira derecha
    }

    public void Up()
    {
        //Mira arriba
    }

 

    private void AddGravity()
    {
        switch (actualDirection)
        {
            case direction.Up:
                acceleration += Vector2.up;
                break;
            case direction.Down:
                acceleration += Vector2.down;
                break;
            case direction.Right:
                acceleration += Vector2.right;
                break;
            case direction.Left:
                acceleration += Vector2.left;
                break;
        }
    }


    private void ResolveCollison()
    {
        ceilingContact = SolveCollision(Vector2.up);

        leftContact = SolveCollision(Vector2.left);

        rigthContact = SolveCollision(Vector2.right);

        groundContact = SolveCollision(Vector2.down);


    }


    private bool SolveCollision(Vector2 directionTo)
    {
        var hit = Physics2D.Raycast(transform.position, directionTo);
        bool rayHasImpacted = hit.collider != null;
        if (rayHasImpacted)
        {
            bool impactDistanceIsLowerThanHalfHeight = hit.distance < colliderHeight;
            if (impactDistanceIsLowerThanHalfHeight)
            {
                float overlapAmount = colliderHeight - hit.distance;
                Vector2 overlapDirection = -directionTo;
                transform.position += (Vector3)overlapDirection * overlapAmount;

                var normalSpeed = Vector3.Project(speed, hit.normal);
                var projectedSpeed = speed - (Vector2)normalSpeed;

                speed = projectedSpeed;
            }
            return impactDistanceIsLowerThanHalfHeight;
        }
        return false;
    }
}
