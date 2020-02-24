using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public AudioSource popSound;
    public TextMeshProUGUI ptsText;

    private void OnTriggerEnter(Collider other)
    {
        score++;
        ptsText.text = (score * 10) + " pts";
        popSound.pitch = (Random.Range(0.6f, .9f));
        popSound.Play();
    }
}
