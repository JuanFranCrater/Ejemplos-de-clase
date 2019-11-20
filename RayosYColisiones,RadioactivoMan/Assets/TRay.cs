using UnityEngine;

public class TRay : MonoBehaviour
{
    public LayerMask layerMask;
    //private RaycastHit hit;
    private RaycastHit[] hits;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red, 2f);
        /* if (Physics.Raycast(transform.position, transform.forward, 2f))
         {
             Debug.Log("Tengo algo delante");
         }*/
        /*if (Physics.Raycast(transform.position, transform.forward, 2f, layerMask))
        {
            Debug.Log("Tengo algo delante");
        }*/
        /* if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, layerMask))
         {
             if (hit.collider != null)
             {
                 Debug.Log(hit.collider.gameObject + " a " + hit.distance + " unidades de distancia");
             }
         }*/
        hits = Physics.RaycastAll(transform.position, transform.forward,  2f, layerMask);
        for(int i = 0;i<hits.Length;i++)
        {
            Debug.Log(hits[i].collider.gameObject);
        }
        
    }
}
