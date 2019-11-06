using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject hasBoomImg;
    public TextMeshProUGUI txtPuntos;

    public TextMeshProUGUI txtTiempo;

    public int score = 0;
    public bool hasBoom = false;
    public bool hasTriple = false;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        listadoEnemigos = new List<GameObject>();
    }

    internal void addScore(int puntos)
    {
        score = score + puntos;
        txtPuntos.SetText(score + " pts");
    }

    internal void setBoom(bool v)
    {
        hasBoom = v;
        hasBoomImg.SetActive(v);
    }

    internal void setTypeBullet(bool v)
    {
        hasTriple = v;
    }

    public GameObject[] hazard;
    public Vector3[] spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private List<GameObject> listadoEnemigos;
    private int numRound = 0;
    public int maxNumRound;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (numRound<maxNumRound)
        {
            switch (numRound)
            {
                case 0:
                    InitHazard(1, 0, 0);
                    break;
                case 1:
                    InitHazard(4, 0, 0);
                    break;
                case 2:
                    InitHazard(3, 1, 0);
                    break;
                case 3:
                    InitHazard(2, 2, 0);
                    break;
                case 4:
                    InitHazard(4, 3, 0);
                    break;
                case 5:
                    InitHazard(2, 2, 0);
                    break;
                case 6:
                    InitHazard(2, 2, 0);
                    break;
                case 7:
                    InitHazard(3, 3, 0);
                    break;
                case 8:
                    InitHazard(4, 4, 0);
                    break;
                case 9:
                    InitHazard(0, 0, 1);
                    break;
            }
            numRound++;
            StartCoroutine(contadorRonda());
            yield return new WaitForSeconds(waveWait);
            foreach (GameObject item in listadoEnemigos)
            {
                if(item !=null)
                item.GetComponent<Path>().GoToDie();
            }
            listadoEnemigos.Clear();
           
        }
    }

    void InitHazard(int normales, int rapidos, int apuntadores)
    {
        for (int i = 0; i < normales; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValues[i].x, spawnValues[i].y, spawnValues[i].z);
            Quaternion spawnRotation = Quaternion.identity;
            listadoEnemigos.Add(Instantiate(hazard[0], spawnPosition, spawnRotation));
        }
        for (int i = 0; i < rapidos; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValues[i].x, spawnValues[i].y, spawnValues[i].z);
            Quaternion spawnRotation = Quaternion.identity;
            listadoEnemigos.Add(Instantiate(hazard[1], spawnPosition, spawnRotation));
        }
        for (int i = 0; i < apuntadores; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValues[i].x, spawnValues[i].y, spawnValues[i].z);
            Quaternion spawnRotation = Quaternion.identity;
            listadoEnemigos.Add(Instantiate(hazard[2], spawnPosition, spawnRotation));
        }
    }
    IEnumerator contadorRonda()
    {
        for (int i = 0; i < waveWait; i++)
        {
                txtTiempo.SetText("Siquiente ronda en " + (waveWait - i) + " segundos");
                yield return new WaitForSeconds(1);
        }
    }
}
