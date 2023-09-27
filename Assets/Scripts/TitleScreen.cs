using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    GameManager sceneLoadManager;
    Options options;

    void Start()
    {
        sceneLoadManager = FindObjectOfType<GameManager>();
        options = FindObjectOfType<Options>();
    }

    void Update()
    {
        
    }

    public void OpenOptions()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
        options.Open();
    }
    public void OpenCredits()
    {
        sceneLoadManager.LoadScene(GameManager.Scenes.endScreen);
    }
    public void OpenGameplay()
    {
        sceneLoadManager.LoadScene(GameManager.Scenes.gameplay);
    }

    public void Reappear()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
}