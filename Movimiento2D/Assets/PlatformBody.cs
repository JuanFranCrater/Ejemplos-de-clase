using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBody : Body, IControlable
{
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
        if (groundContact)
        {
            acceleration = jumpPower * Vector2.up;
        }
        else if (rigthContact)
        {
            acceleration = jumpPower * Vector2.up + Vector2.left*jumpPower;
        } else if (leftContact)
        {
            acceleration = jumpPower * Vector2.up + Vector2.right * jumpPower;
        }

    }

    public void Action()
    {
        throw new NotImplementedException();
    }
}
public class Body : MonoBehaviour
{
    public float power = 10f;
    public float bounceFactor = 0.75f;
    public float jumpPower = 50f;
    public float gravityScale = 1f;
    public float dragFactor = 0.001f;
    protected Vector2 acceleration;

    protected Vector2 speed;
    private float colliderHeight = 0.5f;
    public float maxSpeed = 3;

    protected bool groundContact;
    protected bool rigthContact;
    protected bool leftContact;
    protected bool ceilingContact;
  
    private void FixedUpdate()
    {
        AddForces();
        LimitMaxSpeed();
        Integrate();
        ResolveCollison();
    }

    private void LimitMaxSpeed()
    {
        if (speed.magnitude > maxSpeed)
        {
            speed = speed.normalized * maxSpeed;
        }

        //speed = new Vector2(Mathf.Clamp(speed.x, -maxSpeed, maxSpeed), Mathf.Clamp(speed.y, -maxSpeed, maxSpeed));
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

                speed = projectedSpeed - (Vector2)normalSpeed * bounceFactor;
            }
            return impactDistanceIsLowerThanHalfHeight;
        }
        return false;
    }

    private void AddForces()
    {
        acceleration += Physics2D.gravity * gravityScale;
        speed *= (1f - dragFactor);
    }

    public void AddAccel(Vector2 accel)
    {
        acceleration += accel;
    }

    private void Integrate()
    {
        speed += acceleration * Time.fixedDeltaTime;
        transform.position += (Vector3)speed * Time.fixedDeltaTime;
        acceleration = Vector2.zero;
    }
}