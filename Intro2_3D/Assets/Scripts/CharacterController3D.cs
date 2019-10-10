using UnityEngine;
using System.Collections;

public class CharacterController3D : MonoBehaviour
{
    [Header("Movement")]
    public string horizontalAxis;
    public string verticalAxis;
    public float moveSpeed;
    public float rotateSpeed;

    private Rigidbody _rb;
    private Animator _anim;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw(horizontalAxis);
        float v = Input.GetAxisRaw(verticalAxis);

        CheckMove(h, v);
    }

    private void CheckMove(float h, float v)
    {
        if (h != 0 || v != 0)
        {
            Rotate(h, v);
            transform.Translate(new Vector3(0, 0, Time.deltaTime * moveSpeed));
            if(_anim)
                _anim.SetBool("Walk", true); 
        }
        else if(_anim)
            _anim.SetBool("Walk", false);
    }

    private void Rotate(float h, float v)
    {
        Vector3 targetDirection = new Vector3(h, 0f, v);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime));
    }    
}
