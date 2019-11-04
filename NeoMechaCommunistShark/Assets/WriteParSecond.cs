using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteParSecond : MonoBehaviour
{
    public string textoAEscribir;
   public TextMeshProUGUI textMeshpro;
       char[] textoAEscribirPorCaracter;
    int position = 0;
    // Update is called once per frame
    private void Awake()
    {
        textoAEscribirPorCaracter = textoAEscribir.ToCharArray();
        StartCoroutine(escribir());
    }
    private IEnumerator escribir()
    {
        if (position < textoAEscribirPorCaracter.Length)
        {
            textMeshpro.SetText(textMeshpro.text + textoAEscribirPorCaracter[position]);
            position++;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(escribir());
        }
    }
}
