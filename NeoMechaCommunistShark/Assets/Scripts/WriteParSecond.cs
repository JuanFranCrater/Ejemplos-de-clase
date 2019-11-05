using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteParSecond : MonoBehaviour
{
    private string textoAEscribir = "El capitalismo ha acabado con la vida en la superficie terrestre.\n"
                                    + "Tras millones de años de evolucion, los animales subacuaticos han ganado conocimiento, y para no repetir los fallos que cometieron los humanos, se han unido en hermandad bajo una misma bandera, la comunista. Pero aunque los humanos ya no se encuentren entre nosotros, sus errores del pasado siguen provocando catastrofes.\n"
                                    + "Hace exactamente 1944 miles de años los humanos lanzaron libros al espacio en forma de ondas, entre ellos, el Mein Kampf. Una raza primitiva de alienigenas tomo este libro como guia espiritual y se han dedicado a conquistar y aniquilar planetas por todo el universo. \n"
                                    + "Ahora que se acercan a la tierra, la URSS, Union de Republicas Socialistas Subacuaticas, ha mandado a su mejor agente a acabar con la amenaza. Ese, eres tu.";
   public TextMeshProUGUI textMeshpro;
    int position = 0;   
    char[] textoAEscribirPorCaracter;
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
            yield return new WaitForSeconds(0.09f);
            StartCoroutine(escribir());
        }
    }
}
