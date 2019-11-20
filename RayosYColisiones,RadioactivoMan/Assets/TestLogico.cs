using UnityEngine;

public class TestLogico : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Soy "+gameObject+" y entro en "+other.gameObject);
        Debug.Log($"Soy {gameObject} y entro en {other.attachedRigidbody.gameObject}");
    }

}
