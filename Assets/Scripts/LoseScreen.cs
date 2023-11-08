using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    GameManager gameManager;

    bool onScreen = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ReturnToTitle()
    {
        gameManager.LoadScene(GameManager.Scenes.titleScreen);
    }

    public void Reappear()
    {
        onScreen = true;
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
    public void Dissapear()
    {
        onScreen = false;
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown && onScreen)
            ReturnToTitle();
    }
}