using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlendTrees
{
    public class SimpleThirdPersonCamera : MonoBehaviour
    {
       public static SimpleThirdPersonCamera Instance { get; private set; }

        public float RotationSpeed = 1f;

        public bool InvertXAxes = false;
        public bool InvertYAxes = false;

        public Transform Target;

        private float m_RotationX = 0f;
        private float m_RotationY = 0f;
        private void Awake()
        {
            Instance = this;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void LateUpdate()
        {
            if(!PlayerController.Instance.AimEnabled)
            RotateCamera();
        }

        private void RotateCamera()
        {
            m_RotationX += (Input.GetAxis("Mouse X") * RotationSpeed) * (InvertXAxes ? -1 : 1);
            m_RotationY += (Input.GetAxis("Mouse Y") * RotationSpeed) * (InvertYAxes ? -1 : 1);

            m_RotationY = Mathf.Clamp(m_RotationY, -35, 60);

            transform.LookAt(Target);
            Target.rotation = Quaternion.Euler(m_RotationY, m_RotationX, 0);
        }

    }
}