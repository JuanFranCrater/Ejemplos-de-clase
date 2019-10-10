using UnityEngine;
using System.Collections;

public class CameraFollow3D : MonoBehaviour
{
    public Transform Target;

    private Vector3 _offset;

    void Awake()
    {
        _offset = transform.position;
    }

    private void Update()
    {
        transform.position = Target.transform.position + _offset;
    }
}
