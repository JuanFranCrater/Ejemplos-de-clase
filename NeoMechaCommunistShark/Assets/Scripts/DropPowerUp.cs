using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerUp : MonoBehaviour
{
    public GameObject[] dropDowns;
    public void dropPowerUp(Transform transform)
    {
        if (GameControl.instance.score % 3 == 0)
        {
            Quaternion spawnRotation = Quaternion.identity;
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().currentHealth < 5)
            {
                Instantiate(dropDowns[0], transform.position, spawnRotation);
            }
            else
            if (!GameControl.instance.hasTriple)
            {
                Instantiate(dropDowns[1], transform.position, spawnRotation);
            }
            else
            if (!GameControl.instance.hasBoom)
            {
                Instantiate(dropDowns[2], transform.position, spawnRotation);
            }
            else {
                Instantiate(dropDowns[0], transform.position, spawnRotation);
            }
        }
    }
}
