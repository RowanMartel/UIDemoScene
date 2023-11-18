using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmRollPickup : MonoBehaviour
{
    [SerializeField] float fillAmount;
    [SerializeField] AudioClip filmRollClip;
    SoundManager soundManager;

    private void Start()
    {
        soundManager = Singleton.instance.GetComponentInChildren<SoundManager>();
    }

    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * 30, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        soundManager.PlaySFX(filmRollClip);
        Singleton.instance.GetComponentInChildren<FilmMeter>().FillMeter(fillAmount);
        Destroy(gameObject);
    }
}