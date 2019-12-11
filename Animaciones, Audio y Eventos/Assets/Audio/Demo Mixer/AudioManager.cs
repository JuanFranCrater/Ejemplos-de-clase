using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Test")]
    public bool testNormal;
    public bool testSfx;
    public bool testBattle;
    public bool testVoice;

    [Header("Audio")]
    public float transitionTime;
    public AudioMixerSnapshot normalSnapshot;
    public AudioMixerSnapshot battleSnapshot;
    public AudioMixerSnapshot voiceSnapshot;
    public AudioSource battleMusic;
    public AudioSource sfx;
    public AudioSource voiceAudio;
	
	// Update is called once per frame
	void Update ()
    {
        if(testNormal)
        {
            testNormal = false;
            NormalMusic();
        }

        if(testSfx)
        {
            testSfx = false;
            sfx.Play();
        }

        if(testBattle)
        {
            testBattle = false;
            BattleMusic();
        }

        if(testVoice)
        {
            testVoice = false;
            StartVoice();
        }
	}

    private void NormalMusic()
    {
        normalSnapshot.TransitionTo(transitionTime);
    }

    private void BattleMusic()
    {
        battleMusic.Stop();
        battleMusic.Play();
        battleSnapshot.TransitionTo(transitionTime);
    }

    private void StartVoice()
    {
        voiceAudio.Play();
        voiceSnapshot.TransitionTo(0.1f);
        Invoke("NormalMusic", voiceAudio.clip.length);
    }
}
