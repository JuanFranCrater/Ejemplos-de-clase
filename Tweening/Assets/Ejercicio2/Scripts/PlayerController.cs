using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public Light flash;

    public float MaxSpeed;
    public float MaxRotationSpeed;

    public bool AimEnabled { get; private set; }

    private Rigidbody m_RigidBody;
    private Camera m_Camera;
    private Animator m_Animator;
    public Animator gunAmin;

    private float m_MoveX;
    private float m_MoveY;
    private float m_CurrentSpeed;
    private float m_SpeedDampTime = 0.1f;

    private void Awake()
    {
        Instance = this;
        m_RigidBody = GetComponent<Rigidbody>();
        m_Camera = Camera.main;
        m_Animator = GetComponent<Animator>();
    }

    internal void shoot()
    {
        flash.gameObject.SetActive(true);
        gunAmin.SetTrigger("Shoot");
        StartCoroutine(deactivatedLight());
    }

    IEnumerator deactivatedLight()
    {
        yield return new WaitForSeconds(0.1f);
        flash.gameObject.SetActive(false);
    }

    internal void SetAimCoordinates(float m_AimX, float m_AimY, bool m_AimMode)
    {
        this.AimEnabled = m_AimMode;
        m_Animator.SetBool("AimMode",m_AimMode);
        m_Animator.SetFloat("AimX", m_AimX, m_SpeedDampTime, Time.deltaTime);
        m_Animator.SetFloat("AimY", m_AimY, m_SpeedDampTime, Time.deltaTime);
    }

    private void Update()
    {
        GetInputs();
        UpdateCharacterAnimator();
    }

    private void FixedUpdate()
    {
        if(!AimEnabled)
        {
            MoveCharacter();
            RotateCharacter();
        }
    }

    private void RotateCharacter()
    {
        //Rotacion X-Z del input 
        Vector3 rotation = new Vector3(m_MoveX, 0f, m_MoveY);

        //Rotamos el vector para que se ajuste a la rotacion de la camara
        rotation = Quaternion.Euler(0, m_Camera.transform.eulerAngles.y, 0) * rotation;

        if (rotation != Vector3.zero)
        {
            //Obtenemos la rotacion final

            Quaternion quatR = Quaternion.LookRotation(rotation);

            m_RigidBody.MoveRotation(Quaternion.Lerp(m_RigidBody.rotation, quatR, Time.deltaTime * MaxRotationSpeed));
        }
    }

    private void MoveCharacter()
    {
        //Movimiento x-z del input
        Vector3 movement = new Vector3(m_MoveX, 0f, m_MoveY);
        //Cuan fuerte apretamos el joistic
        m_CurrentSpeed = (movement.magnitude > 1 ? 1 : movement.magnitude);

        //Normalizamos y lo hacemos proporcional
        movement = movement.normalized * MaxSpeed * Time.deltaTime;

        //Rotamos el vector para que se ajuste a la rotacion de la camara
        movement = Quaternion.Euler(0, m_Camera.transform.eulerAngles.y, 0) * movement;

       //Desplazamos
        m_RigidBody.MovePosition(transform.position + (movement * m_CurrentSpeed));
    }

    private void GetInputs()
    {
        m_MoveX = Input.GetAxis("Horizontal");
        m_MoveY = Input.GetAxis("Vertical");
    }

    private void UpdateCharacterAnimator()
    {
        m_Animator.SetFloat("Speed", m_CurrentSpeed, m_SpeedDampTime, Time.deltaTime);   
    }
}
