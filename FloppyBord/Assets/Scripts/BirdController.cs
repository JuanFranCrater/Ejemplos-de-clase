using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float moveSpeed;
    public float impulseForce;
    public KeyCode impulseKey;
    private AudioSource _audioS;

    void Awake()
    {
        _audioS = GetComponent<AudioSource>();
    }


	void Update ()
    {
        if(Input.GetKeyDown(impulseKey))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * impulseForce);
            if(_audioS != null)
                _audioS.Play();
        }

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
	}
}
