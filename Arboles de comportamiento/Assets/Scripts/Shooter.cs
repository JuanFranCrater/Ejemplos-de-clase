using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour
{
    public KeyCode shootKey;
    public Transform shootStart;
    public List<GameObject> bulletList;
    private AudioSource audioS;

    void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(shootKey))
        {
            GameObject bullet = GetFreeBullet();
            PrepareBullet(bullet);
        }
    }

    private GameObject GetFreeBullet()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if(bulletList[i].activeInHierarchy == false)
            {
                return bulletList[i];
            }
        }
        return null;
    }

    private void PrepareBullet(GameObject bullet)
    {
        if(bullet != null)
        {
            bullet.transform.position = shootStart.position;
            bullet.transform.forward = shootStart.forward;
            bullet.SetActive(true);
            audioS.Play();
        }
    }
}
