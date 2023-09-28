using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameManager gameManager;
    Options options;
    SoundManager soundManager;

    [SerializeField] AudioClip funnyNoise;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        options = FindObjectOfType<Options>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager.paused) Close();
            else Open();
        }
    }

    public void Open()
    {
        gameManager.paused = true;
        Time.timeScale = 0;

        Reappear();
    }
    public void Close()
    {
        gameManager.paused = false;
        options.Close();
        Time.timeScale = 1;

        Dissapear();
    }

    public void OpenOptions()
    {
        Dissapear();
        options.Open();
    }

    public void OpenTitle()
    {
        Time.timeScale = 1;
        gameManager.LoadScene(GameManager.Scenes.titleScreen);
    }

    public void PlayFunnyNoise()
    {
        soundManager.PlaySFX(funnyNoise);
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