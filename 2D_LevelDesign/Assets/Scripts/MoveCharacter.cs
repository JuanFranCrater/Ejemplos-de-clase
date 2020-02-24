using System;
using System.Collections;
using UnityEngine;

public class MoveCharacter : Body, IControlable
{
    private bool doubleJump = true;

    public void Left()
    {
        acceleration = power * Vector2.left;
    }

    public void Right()
    {
        acceleration = power * Vector2.right;
    }

    public void Jump()
    {
        if (groundContact)
        {
            acceleration = jumpPower * Vector2.up;
        }
        else if (rigthContact)
        {
            acceleration = jumpPower * Vector2.up + Vector2.left * jumpPower;
        }
        else if (leftContact)
        {
            acceleration = jumpPower * Vector2.up + Vector2.right * jumpPower;
        }
        if (!groundContact && doubleJump)
        {
            acceleration = jumpPower * Vector2.up;
            doubleJump = false;
            StartCoroutine(activateDoubleJump());
        }

    }

    private IEnumerator activateDoubleJump()
    {
        yield return new WaitForSeconds(0);
        if (groundContact)
        {
            doubleJump = true;
        }
        else
        {
            StartCoroutine(activateDoubleJump());
        }
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
    public Animator _anim;
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
        CheckAnimation();
        Integrate();
        ResolveCollison();
    }

    private void CheckAnimation()
    {
        _anim.SetBool("Grounded", groundContact);
        _anim.SetFloat("Velocity", acceleration.x);
    }

    private void LimitMaxSpeed()
    {
        if (speed.magnitude > maxSpeed)
        {
            speed = speed.normalized * maxSpeed;
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
        if (rayHasImpacted && hit.collider.gameObject.tag != "Destruye")
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
                if (hit.collider.gameObject.tag == "Destruible")
                {
                    StartCoroutine(destruirBloque(2, hit.collider.gameObject));
                }
                if (hit.collider.gameObject.tag == "Object")
                {
                    GameManager.instance.takeGem(hit.collider.gameObject.name);
                    StartCoroutine(destruirBloque(0, hit.collider.gameObject));
                    return false;
                }
                if (hit.collider.gameObject.tag == "Key")
                {
                    if (GameManager.instance.takeKey(hit.collider.gameObject.name))
                    {
                        StartCoroutine(destruirBloque(0, hit.collider.gameObject));
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return impactDistanceIsLowerThanHalfHeight;
        }
        else
        {
            if (hit.collider != null && hit.collider.gameObject.tag == "Destruye" && hit.distance < colliderHeight/2)
            {
                Destroy(gameObject);
            }
        }
        return false;
    }

    private IEnumerator destruirBloque(int time, GameObject gameObject)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }

    private void AddForces()
    {
        acceleration += Physics2D.gravity * gravityScale;
        speed *= (1f - dragFactor);
    }

    private void Integrate()
    {
        speed += acceleration * Time.fixedDeltaTime;
        transform.position += (Vector3)speed * Time.fixedDeltaTime;
        acceleration = Vector2.zero;
    }
}