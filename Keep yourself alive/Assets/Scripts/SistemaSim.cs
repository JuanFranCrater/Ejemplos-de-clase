using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SistemaSim : MonoBehaviour
{
    KeyCode[] st = {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z };
    string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private KeyCode teclaCode;
    private char tecla;
    public TextMeshProUGUI teclaText;



    public float state;
    public Image vidaImg;

    public int difficulty;
    private float recuperacion;
    private float danio;
    private float limitMax;
    private float limitMin;
    public GameObject vidaObjeto;
    private Health vidaGeneral;

    private Transform posicionInicial;

    void Start()
    {
        posicionInicial = GetComponent<Transform>();
        vidaGeneral = vidaObjeto.GetComponent<Health>();

        int position = Random.Range(0, st.Length);
        tecla = chars[position];
        teclaText.text = tecla.ToString();
        teclaCode = st[position];

        switch (difficulty)
        {
            case 0:
                recuperacion = 2;
                danio = 0.05f;
                limitMax = 80;
                limitMin = 30;
                break;
            case 1:
                recuperacion = 5;
                danio = 0.09f;
                limitMax = 70;
                limitMin = 20;
                break;
            case 2:
                recuperacion = 7;
                danio = 0.01f;
                limitMax =100;
                limitMin = 50;
                break;
            case 3:
                recuperacion = 15;
                danio = 0.05f;
                limitMax = 90;
                limitMin = 10;
                break;
            case 4:
                recuperacion = 80;
                danio = 0.01f;
                limitMax =100;
                limitMin = 0;
                break;
            case 5:
                recuperacion = 10;
                danio = 0.1f;
                limitMax = 90;
                limitMin = 10;
                break;
        }
    }

    void FixedUpdate()
    {
        float valorResta = 0;
        if (Input.GetKeyDown(teclaCode))
        {
            valorResta = +recuperacion;
        }
        else
        {
            valorResta = -danio;
        }

        if (state <= 100)
        {
            vidaImg.fillAmount = state / 100f;
            state += valorResta;
        }
        else {
            state = 100;
        }
        
        if (state <= 0)
        {
            state = 0;
        }

        if (state > limitMax || state < limitMin)
        {
            vidaGeneral.hacerDanio();
            doShake();
        }
        else
        {
             GetComponent<Transform>().position = posicionInicial.position;
        }

    }

    private void doShake()
    {
        
    }
}

