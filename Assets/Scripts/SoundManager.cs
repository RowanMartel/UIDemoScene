using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

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