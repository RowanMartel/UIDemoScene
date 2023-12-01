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
    GameManager gameManager;
    BrightnessManager brightnessManager;

    void Start()
    {
        brightnessManager = FindObjectOfType<BrightnessManager>();
        titleScreen = FindObjectOfType<TitleScreen>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        soundManager = FindObjectOfType<SoundManager>();
        gameManager = FindObjectOfType<GameManager>();
        ChangeBGMVolume();
    }

    public void Open()
    {
        Reappear();
    }
    public void Close()
    {
        Dissapear();

        // if in gameplay, reopen the pause menu
        if (gameManager.scene == GameManager.Scenes.gameplay && gameManager.paused)
        {
            pauseMenu.HardOpen();
        }
        // else if on title screen, make the title reappear
        else if (gameManager.scene == GameManager.Scenes.titleScreen)
        {
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
        brightnessManager.SetBrightness(sliderBrightness.value);
    }
    public void ChangeSilliness()
    {
        // nothing
    }

    public void Reappear()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
    public void Dissapear()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }
}