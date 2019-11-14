using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class getPoints : MonoBehaviour
{

    private void Start()
    {

        gameObject.GetComponent<TextMeshProUGUI>().SetText(FindObjectOfType<pointManager>().getPoints().ToString()+ " pts");
    }
}
