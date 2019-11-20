using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encontrar : MonoBehaviour
{
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        player = FindObjectOfType<PlayerScript>().gameObject;
        player = GameObject.FindGameObjectWithTag("Player");

        PlayerScript[] players = FindObjectsOfType<PlayerScript>();
        foreach (PlayerScript ps in players)
            ps.Init();
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Init();    
        }

    }
}
