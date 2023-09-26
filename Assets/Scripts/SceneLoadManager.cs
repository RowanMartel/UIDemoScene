using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public enum Scenes
    {
        titleScreen,
        gameplay,
        endScreen
    }

    public void LoadScene(Scenes newScene)
    {
        switch (newScene)
        {
            case Scenes.titleScreen:
                SceneManager.LoadScene(0);
                break;
        }
    }
}