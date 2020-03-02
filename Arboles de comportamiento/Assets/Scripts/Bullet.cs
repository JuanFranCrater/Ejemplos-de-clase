using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public float lifeTime;

    void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>())
        {
            other.GetComponent<Health>().UpdateHealth(-damage);
            CancelInvoke("Deactivate");
            Deactivate();
        }
    }

	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
