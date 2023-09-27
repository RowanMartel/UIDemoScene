using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;

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
        soundManager = FindObjectOfType<SoundManager>();
        
    }


    public void LoadScene(Scenes newScene)
    {
        soundManager.SetBGM(null);
        switch (newScene)
        {
            case Scenes.titleScreen:
                SceneManager.LoadScene(0);
                break;
            case Scenes.gameplay:
                SceneManager.LoadScene(1);
                break;
            case Scenes.endScreen:
                SceneManager.LoadScene(2);
                break;
        }
    }
    public Scenes GetScene()
    {
        SceneManager.GetSceneByBuildIndex(0);
        switch (SceneManager.GetActiveScene())
        {
            case SceneManager.GetSceneByBuildIndex(0):
                return Scenes.titleScreen;
            case SceneManager.GetSceneByBuildIndex(1):
                return Scenes.gameplay;
            case SceneManager.GetSceneByBuildIndex(2):
                return Scenes.endScreen;
        }
        return Scenes.titleScreen;
    }
}