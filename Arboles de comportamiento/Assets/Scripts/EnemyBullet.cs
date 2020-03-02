using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public float lifeTime;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
        GetComponent<Animator>().SetBool("Scale", true);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            other.GetComponent<Health>().UpdateHealth(-damage);
        }
        Destroy(gameObject);
    }
}
