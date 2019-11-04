using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioScriptManager : MonoBehaviour
{
    
    private void OnMouseOver()
    {
        Debug.Log("Music");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }
    private void OnMouseExit()
    {
        Debug.Log("Music Stop");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }
}
