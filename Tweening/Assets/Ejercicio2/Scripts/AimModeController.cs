using System.Collections;
using UnityEngine;

public class AimModeController : MonoBehaviour
{
    public float AimPrecision = 0.05f;
    public float SliceTime = 0.05f;
    public float SliceDelay = 0.25f;

    private Vector3 m_CurrentDirection;

    private bool m_AimMode;

    private float m_AimX;
    private float m_AimY;
    private bool m_Slice;
    private bool m_HasSliced;

    private void Update()
    {
        GetInputs();
        Aim();
        Slice();
    }

    private void Slice()
    {
        if (m_Slice && !m_HasSliced)
        {
            PlayerController.Instance.shoot();
            StartCoroutine(SliceCoolDown());
        }
    }

    private IEnumerator SliceCoolDown()
    {
        m_HasSliced = true;
        yield return new WaitForSeconds(SliceDelay);
        m_HasSliced = false;
    }

    private void Aim()
    {
       PlayerController.Instance.SetAimCoordinates(m_AimX, m_AimY, m_AimMode);
    }

    private void GetInputs()
    {
        m_AimX += Input.GetAxis("Mouse X") * AimPrecision;
        m_AimY += Input.GetAxis("Mouse Y") * AimPrecision;

        m_AimX = Mathf.Clamp(m_AimX, -1, 1);
        m_AimY = Mathf.Clamp(m_AimY, -1, 1);

        m_AimMode = Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Joystick1Button4);
        m_Slice = m_AimMode && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Joystick1Button5));
    }
}
