using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField] AudioClip BGM;
    SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.SetBGM(BGM);
        soundManager.UnpauseBGM(this, EventArgs.Empty);
    }
}