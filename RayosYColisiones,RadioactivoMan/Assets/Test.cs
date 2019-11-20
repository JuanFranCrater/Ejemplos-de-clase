using UnityEngine;

public class Test : MonoBehaviour
{
    private bool playerColisi = false;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            playerColisi = true;
            Debug.Log("Entro en " + collision.gameObject); // Muestra el player
            Debug.Log("Entro en " + collision.collider.gameObject); // Muestra la cabeza
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            playerColisi = false;
            Debug.Log("Salgo de " + collision.collider.gameObject); // Muestra la cabeza
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            // Debug.Log("Estoy en " + collision.gameObject); // Muestra la player
            //Para no usar collisionstay, se usan variables en enter y exit
        }
    }
    private void Update()
    {
        if (playerColisi)
        {
            Debug.Log("Estoy colisionando");
        }
    }
}
