using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour
{
    public string killerTag;
    public float deathDelay;
    private Animator _anim;
    private bool _killed;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == killerTag)
        {
            Destroy(col.gameObject);

            if(_anim && !_killed)
                _anim.SetTrigger("Die");
            Destroy(gameObject, deathDelay);

            _killed = true;
        }
    }
}
