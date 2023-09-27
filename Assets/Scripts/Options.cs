using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Slider sliderBGM;
    [SerializeField] Slider sliderSFX;
    [SerializeField] Slider sliderBrightness;
    [SerializeField] Slider sliderSilliness;
    SoundManager soundManager;
    PauseMenu pauseMenu;
    TitleScreen titleScreen;

    void Start()
    {
        titleScreen = FindObjectOfType<TitleScreen>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        soundManager = FindObjectOfType<SoundManager>();
        ChangeBGMVolume();
    }

    public void Open()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
    public void Close()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        // if in gameplay, reopen the pause menu
        if (pauseMenu)
        {
            Debug.Log("A");
            if (pauseMenu.paused)
                pauseMenu.Open();
        }
        // else if on title screen, make the title reappear
        else if (titleScreen)
        {
            Debug.Log("BA");
            titleScreen.Reappear();
        }
    }

    public void ChangeBGMVolume()
    {
        soundManager.SetBGMVol(sliderBGM.value);
    }
    public void ChangeSFXVolume()
    {

        soundManager.SetSFXVol(sliderSFX.value);
    }
    public void ChangeBrightness()
    {

    }
    public void ChangeSilliness()
    {
        // nothing
    }
}