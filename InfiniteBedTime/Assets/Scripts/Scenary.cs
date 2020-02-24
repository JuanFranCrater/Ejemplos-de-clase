using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenary : MonoBehaviour
{
    public GameObject[] decoration;
    public GameObject[] decorationPosition;
    public GameObject scenaryObject;
    private GameObject scene;
    public float speed;

    private void Start()
    {
        scene = transform.parent.gameObject;
        int rand = Random.Range(0, decoration.Length);
        for (int i = 0; i < decorationPosition.Length; i++)
        {

            GameObject scenaryRnd = Instantiate(decoration[(rand)], decorationPosition[i].transform.position, Quaternion.identity);
            scenaryRnd.GetComponentInChildren<Transform>().Rotate(Vector3.up, Random.Range(0, 359));
            scenaryRnd.transform.parent = transform;
            rand = Random.Range(0, decoration.Length);
        }
        if(tag != "Respawn")
        StartCoroutine(instantiateMyself());
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0.0f, 0.0f, speed) * Time.deltaTime;
    }

    public IEnumerator instantiateMyself()
    {
        yield return new WaitForSeconds(15);
        if (scene.transform.childCount <= 4)
        {
            Vector3 remotePos = transform.position + new Vector3(0, 0, -65f);
            GameObject newScenary = Instantiate(scenaryObject, remotePos, Quaternion.identity);
            newScenary.transform.parent = transform.parent;
        }
        else {
            StartCoroutine(instantiateMyself());
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
