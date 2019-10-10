using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject prefabtoInstantiate;
    public Vector3 maxOffset;
    public float instantiateTime;
    private float _instantiateTimer;

    void Start()
    {
        _instantiateTimer = instantiateTime;
    }

    void Update()
    {
        _instantiateTimer -= Time.deltaTime;
        if(_instantiateTimer <= 0)
        {
            Vector3 position = transform.position + new Vector3(Random.Range(-maxOffset.x, maxOffset.x), Random.Range(-maxOffset.y, maxOffset.y), Random.Range(-maxOffset.z, maxOffset.z));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject obj = (GameObject) Instantiate(prefabtoInstantiate, position, rotation);
            obj.transform.SetParent(this.transform);
            _instantiateTimer = instantiateTime;
        }
    }
}
