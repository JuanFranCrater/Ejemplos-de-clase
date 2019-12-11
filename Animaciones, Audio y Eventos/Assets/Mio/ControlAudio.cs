using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip swordClip;
    public AudioClip shootClip;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*audio.clip = shootClip;
            audio.Play();//Corta los otros sonidos producidos por este audioSource


            audio.PlayOneShot(shootClip); //No corta unos a otros
            */
        }
        else if (Input.GetKey(KeyCode.Return))
        {
            /*audio.clip = swordClip;
            audio.Play();//Corta los otros sonidos producidos por este audioSource


            audio.PlayOneShot(swordClip); //No corta unos a otros
            */
        }
    }
}
