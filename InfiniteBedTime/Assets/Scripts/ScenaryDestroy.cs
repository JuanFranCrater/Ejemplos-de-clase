using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryDestroy : MonoBehaviour
{
   
    void DestroyChildFirst()
    {
            Destroy(transform.GetChild(0).gameObject);
    }
}
