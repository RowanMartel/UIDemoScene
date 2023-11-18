using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    GameManager sceneLoadManager;
    MeshCollider meshCollider;
    MeshRenderer meshRenderer;

    void Start()
    {
        Singleton.instance.GetComponentInChildren<FilmMeter>().FilmMeterChanged += OnFilmMeterChanged;

        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        sceneLoadManager = FindObjectOfType<GameManager>();

        meshCollider.enabled = false;
        meshRenderer.enabled = false;
    }

    void OnFilmMeterChanged(object source, FilmMeterChangedEventArgs e)
    {
        if (e.fillAmount == 1)
        {
            meshCollider.enabled = true;
            meshRenderer.enabled = true;
        }
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