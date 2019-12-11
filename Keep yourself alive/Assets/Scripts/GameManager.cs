using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelJuego;
    public GameObject panelFin;
    public TextMeshProUGUI cuentaAtras;
    int cuenta = 10;
    public string escena;
    public int vida = 100;
    public Image vidaImg;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void inicioJuego()
    {
        panelInicio.SetActive(false);
        panelJuego.SetActive(true);
        StartCoroutine(escribir());
    }

    private IEnumerator escribir()
    {
        if (cuenta!=0)
        {
            contador();
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine(escribir());
        }
        else {
            activarTiempo();
        }
}
    private IEnumerator aumentarTiempo()
    {
        yield return new WaitForSecondsRealtime(5f);

        Time.timeScale = Time.timeScale + 0.01f;
        StartCoroutine(aumentarTiempo());
    }

    public void activarTiempo()
    {
        Time.timeScale = 1;
        cuentaAtras.text = "";
    }
    public void contador()
    {
        cuentaAtras.text = cuenta.ToString();
        cuenta--;
    }
    public void finJuego()
    {
        panelFin.SetActive(true);
        Time.timeScale = 0;
    }

    public void salir()
    {
        Application.Quit();
    }
    public void reiniciar()
    {
        SceneManager.LoadScene(escena);
    }
    void FixedUpdate()
    {
        if (vida <= 0)
        {
            finJuego();
        }
        else
        {
            vidaImg.fillAmount = vida / 100f;
        }
    }

    public void restarVida(int resto)
    {
        vida -= resto;
    }

}
