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

    public bool paused;

    public enum Scenes
    {
        titleScreen,
        gameplay,
        endScreen
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
                break;
            case Scenes.gameplay:
                SceneManager.LoadScene(1);
                titleScreen.Dissapear();
                endScreen.Dissapear();
                break;
            case Scenes.endScreen:
                SceneManager.LoadScene(2);
                titleScreen.Dissapear();
                endScreen.Reappear();
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
                titleScreen.Reappear();
                endScreen.Dissapear();
                scene = Scenes.titleScreen;
                break;
            case 1:
                titleScreen.Dissapear();
                endScreen.Dissapear();
                barkCam.AssignToBark();
                scene = Scenes.gameplay;
                break;
            case 2:
                titleScreen.Dissapear();
                endScreen.Reappear();
                scene = Scenes.endScreen;
                break;
        }
    }
}