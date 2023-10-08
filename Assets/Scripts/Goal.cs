using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    GameManager sceneLoadManager;

    void Start()
    {
        sceneLoadManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            sceneLoadManager.LoadScene(GameManager.Scenes.endScreen);
        else if (other.gameObject.layer == 8)
        {
            other.gameObject.SetActive(false);
        }
    }
}