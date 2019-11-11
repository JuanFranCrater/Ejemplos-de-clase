using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteParSecond : MonoBehaviour
{
   public TextMeshProUGUI textMeshpro;
    int position = 0;   
    char[] textoAEscribirPorCaracter;
    private void Awake()
    {
        textoAEscribirPorCaracter = textMeshpro.text.ToCharArray();
        StartCoroutine(escribir());
    }
    private IEnumerator escribir()
    {
        if (position < textoAEscribirPorCaracter.Length)
        {
            textMeshpro.SetText(textMeshpro.text + textoAEscribirPorCaracter[position]);
            position++;

            yield return new WaitForSeconds(0.001f);
            StartCoroutine(escribir());
        }
    }
}
