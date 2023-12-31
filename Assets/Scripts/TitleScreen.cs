using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    GameManager gameManager;
    Options options;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        options = FindObjectOfType<Options>();
    }

    public void OpenOptions()
    {
        Dissapear();
        options.Open();
    }
    public void OpenCredits()
    {
        gameManager.LoadScene(GameManager.Scenes.endScreen);
    }
    public void OpenGameplay()
    {
        gameManager.LoadScene(GameManager.Scenes.gameplay);
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