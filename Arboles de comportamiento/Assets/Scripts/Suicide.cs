using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    private GameObject target;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    } 

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == target)
        {
            if(target.GetComponent<Health>())
            {
                target.GetComponent<Health>().UpdateHealth(-damage);
            }
            Destroy(gameObject);
        }
    }
}
