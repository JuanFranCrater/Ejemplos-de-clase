using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionPowerUp : MonoBehaviour
{
    public LayerMask layermask;
    public int type;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (layermask == (layermask | (1 << col.gameObject.layer)))
        {
            switch (type)
            {
                case 1:
                    if (col.GetComponent<Health>() != null)
                    {
                        col.GetComponent<Health>().AddHealth(1);
                    }
                    break;
                case 2:
                    GameControl.instance.setTypeBullet(true);
                    break;
                case 3:
                    GameControl.instance.setBoom(true);
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}
