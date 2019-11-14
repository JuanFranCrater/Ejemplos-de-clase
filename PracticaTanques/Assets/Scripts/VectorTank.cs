using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTank : MonoBehaviour
{
    public Vector3 pos;
    public float newScale;
    public Transform redTank;
    void Start()
    {
        transform.Translate(0, 0, 0);
        transform.localScale = transform.localScale * newScale;
        redTank.position = new Vector3(redTank.position.x, pos.y, redTank.position.z);
        redTank.rotation = transform.rotation;

        Debug.Log("La distancia entre los dos tanques es: " +Vector3.Distance(transform.position,redTank.position));
    }

}
