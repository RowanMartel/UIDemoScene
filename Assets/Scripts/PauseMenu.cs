using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    SceneLoadManager sceneLoadManager;

    void Start()
    {
        sceneLoadManager = FindObjectOfType<SceneLoadManager>();
    }

    public void Open(int timeScale = 1)
    {
        Time.timeScale = timeScale;

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
    public void Close(int timescale = 1)
    {
        Time.timeScale = timescale;

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    public void OpenTitle()
    {
        Time.timeScale = 1;
        sceneLoadManager.LoadScene(SceneLoadManager.Scenes.titleScreen);
    }

    public void PlayFunnyNoise()
    {

    }
}