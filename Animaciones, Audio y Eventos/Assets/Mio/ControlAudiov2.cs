using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlAudiov2 : MonoBehaviour
{
    public AudioMixerSnapshot defaultSnapshot;
    public AudioMixerSnapshot battleSnapshot;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            defaultSnapshot.TransitionTo(0.5f);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            battleSnapshot.TransitionTo(0.5f);
        }
    }
}
