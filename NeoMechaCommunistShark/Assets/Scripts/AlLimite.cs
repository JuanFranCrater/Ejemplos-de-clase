using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlLimite : MonoBehaviour
{
    public GameObject myPrefab;

    private void OnBecameVisible()
    {
        generar();
    }
    void generar()
    {
        Instantiate(myPrefab, new Vector3(transform.position.x + 13, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
