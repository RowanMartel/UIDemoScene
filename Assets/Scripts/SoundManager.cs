using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    private void Start()
    {
        Singleton.instance.GetComponentInChildren<GameManager>().pausedEv += PauseBGM;
        Singleton.instance.GetComponentInChildren<GameManager>().unpausedEv += UnpauseBGM;
    }

    public void SetBGM(AudioClip BGM)
    {
        BGMSource.clip = BGM;

        if (BGMSource == null)
            BGMSource.Stop();
        else BGMSource.Play();
    }
    public void PlaySFX(AudioClip SFX)
    {
        SFXSource.PlayOneShot(SFX);
    }

    public void SetBGMVol(float vol)
    {
        BGMSource.volume = vol;
    }
    public void SetSFXVol(float vol)
    {
        SFXSource.volume = vol;
    }

    public void PauseBGM(object sender, EventArgs e)
    {
        BGMSource.Pause();
    }
    public void UnpauseBGM(object sender, EventArgs e)
    {
        BGMSource.UnPause();
    }
}