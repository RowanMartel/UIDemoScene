using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject TMPPauseScreen;
    [SerializeField] GameObject TMPOptionsScreen;
    [SerializeField] GameObject TMPWinScreen;
    [SerializeField] GameObject TMPLoseScreen;

    public enum OverlayScreens
    {
        pauseScreen,
        optionsScreen,
        winScreen,
        loseScreen
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ToggleOverlayScreen(bool toggle, OverlayScreens screen)
    {
        switch (screen)
        {
            case OverlayScreens.pauseScreen:
                TMPPauseScreen.SetActive(toggle);
                break;
            case OverlayScreens.optionsScreen:
                TMPOptionsScreen.SetActive(toggle);
                break;
            case OverlayScreens.winScreen:
                TMPWinScreen.SetActive(toggle);
                break;
            case OverlayScreens.loseScreen:
                TMPLoseScreen.SetActive(toggle);
                break;
        }
    }
}