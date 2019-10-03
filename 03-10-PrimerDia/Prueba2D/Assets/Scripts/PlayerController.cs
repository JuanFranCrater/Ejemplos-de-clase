using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public KeyCode leftMovement, rightMovement;
    private bool _facingRight = true;

    void Update()
    {
        CheckMovement();
    }

    private void CheckMovement()
    {
        if((Input.GetKey(leftMovement) && _facingRight) || (Input.GetKey(rightMovement) && !_facingRight))
        {
            _facingRight = !_facingRight;
            transform.Rotate(Vector3.up * 180f);
        }

        if(Input.GetKey(leftMovement) || Input.GetKey(rightMovement))
            transform.Translate(Vector3.right * maxSpeed * Time.deltaTime);
    }
}
