using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InicioScriptManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
       public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PauseMusic();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }
}
