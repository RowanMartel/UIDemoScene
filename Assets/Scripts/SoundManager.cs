using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource BGMSource;
    AudioSource SFXSource;

    void Start()
    {
        BGMSource = transform.GetChild(0).GetComponent<AudioSource>();
        SFXSource = transform.GetChild(1).GetComponent<AudioSource>();
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
}