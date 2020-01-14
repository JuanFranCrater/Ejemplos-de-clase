using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceConstrains : MonoBehaviour
{
    public Body firstBody;
    public Body secondBody;
    public float targetDistance;
    public float stiffness = 1f;

    private void FixedUpdate()
    {
        var currentDistance = Vector2.Distance(firstBody.transform.position, secondBody.transform.position);

        var error = targetDistance - currentDistance;
        var direction = (firstBody.transform.position - secondBody.transform.position).normalized;

        if (error > 0)
        {
            firstBody.AddAccel(direction * error * 0.5f * stiffness);
            secondBody.AddAccel(-direction * error * 0.5f * stiffness);
        }

    }
}
