using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameManager sceneLoadManager;
    Options options;
    SoundManager soundManager;

    [SerializeField] AudioClip funnyNoise;

    public bool paused;

    void Start()
    {
        paused = false;
        sceneLoadManager = FindObjectOfType<GameManager>();
        options = FindObjectOfType<Options>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Close();
            else Open();
        }
    }

    public void Open()
    {
        paused = true;
        Time.timeScale = 0;

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
    public void Close()
    {
        paused = false;
        options.Close();
        Time.timeScale = 1;

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
        options.Open();
    }

    public void OpenTitle()
    {
        Time.timeScale = 1;
        sceneLoadManager.LoadScene(GameManager.Scenes.titleScreen);
    }

    public void PlayFunnyNoise()
    {
        soundManager.PlaySFX(funnyNoise);
    }
}