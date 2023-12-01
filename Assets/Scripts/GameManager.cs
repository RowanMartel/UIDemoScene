using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    [SerializeField] TitleScreen titleScreen;
    [SerializeField] EndScreen endScreen;
    [SerializeField] BarkCam barkCam;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] LoseScreen loseScreen;
    [SerializeField] Canvas gameplayCanvas;
    [SerializeField] FilmMeter filmMeter;

    public bool paused;

    public enum Scenes
    {
        titleScreen,
        gameplay,
        endScreen,
        loseScreen
    }
    public Scenes scene;

    private void Start()
    {
        paused = false;
        Init();
    }

    public void LoadScene(Scenes newScene)
    {
        soundManager.SetBGM(null);
        scene = newScene;
        switch (newScene)
        {
            case Scenes.titleScreen:
                SceneManager.LoadScene(0);
                titleScreen.Reappear();
                endScreen.Dissapear();
                pauseMenu.GetComponent<PauseMenu>().HardClose();
                loseScreen.Dissapear();
                gameplayCanvas.enabled = false;
                barkCam.Dissapear();
                filmMeter.ResetMeter();
                break;
            case Scenes.gameplay:
                pauseMenu.GetComponent<PauseMenu>().UnlockReturn();
                SceneManager.LoadScene(1);
                titleScreen.Dissapear();
                endScreen.Dissapear();
                pauseMenu.GetComponent<PauseMenu>().HardClose();
                loseScreen.Dissapear();
                gameplayCanvas.enabled = true;
                barkCam.Dissapear();
                break;
            case Scenes.endScreen:
                SceneManager.LoadScene(2);
                titleScreen.Dissapear();
                endScreen.Reappear();
                pauseMenu.GetComponent<PauseMenu>().HardClose();
                loseScreen.Dissapear();
                gameplayCanvas.enabled = false;
                barkCam.Dissapear();
                break;
            case Scenes.loseScreen:
                SceneManager.LoadScene(3);
                titleScreen.Dissapear();
                endScreen.Dissapear();
                pauseMenu.GetComponent<PauseMenu>().HardClose();
                loseScreen.Reappear();
                gameplayCanvas.enabled = false;
                barkCam.Dissapear();
                break;
        }
    }
    public Scenes GetScene()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                return Scenes.titleScreen;
            case 1:
                return Scenes.gameplay;
            case 2:
                return Scenes.endScreen;
        }
        return Scenes.titleScreen;
    }

    void Init()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                gameplayCanvas.enabled = false;
                titleScreen.Reappear();
                endScreen.Dissapear();
                scene = Scenes.titleScreen;
                pauseMenu.GetComponent<PauseMenu>().Close();
                break;
            case 1:
                titleScreen.Dissapear();
                endScreen.Dissapear();
                barkCam.AssignToBark();
                scene = Scenes.gameplay;
                pauseMenu.GetComponent<PauseMenu>().Close();
                break;
            case 2:
                titleScreen.Dissapear();
                endScreen.Reappear();
                scene = Scenes.endScreen;
                pauseMenu.GetComponent<PauseMenu>().Close();
                break;
        }
    }
}