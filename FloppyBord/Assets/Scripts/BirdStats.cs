using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdStats : MonoBehaviour
{
    public Text textPosition;
   
    public void SetPosition(int pos)
    {
        textPosition.text = "#" + pos;
    }
}
