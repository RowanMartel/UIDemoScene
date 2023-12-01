using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    GameManager gameManager;
    Options options;
    SoundManager soundManager;

    [SerializeField] AudioClip funnyNoise;

    [SerializeField] GameObject canceller;
    [SerializeField] Button returnButton;

    bool locked;

    void Start()
    {
        gameManager = Singleton.instance.GetComponentInChildren<GameManager>();
        options = Singleton.instance.GetComponentInChildren<Options>();
        soundManager = Singleton.instance.GetComponentInChildren<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !locked && gameManager.scene == GameManager.Scenes.gameplay)
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
    public void HardOpen()
    {
        gameManager.paused = true;
        Time.timeScale = 0;

        HardReappear();
    }
    public void Close()
    {
        gameManager.paused = false;
        options.Close();
        Time.timeScale = 1;

        Dissapear();
    }
    public void HardClose()
    {
        gameManager.paused = false;
        options.Close();
        Time.timeScale = 1;

        HardDissapear();
    }

    public void OpenOptions()
    {
        HardDissapear();
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
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = Vector3.zero;
        DOTween.To(() => rectTransform.localScale, x => rectTransform.localScale = x, Vector3.one, 0.2f).SetEase(Ease.OutSine).SetUpdate(true);
    }
    public void HardReappear()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = Vector3.one;
    }
    public void Dissapear()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = Vector3.one;
        DOTween.To(() => rectTransform.localScale, x => rectTransform.localScale = x, Vector3.zero, 0.2f).SetEase(Ease.OutSine).SetUpdate(true);
    }
    public void HardDissapear()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    public void LockReturn()
    {
        returnButton.interactable = false;
        canceller.SetActive(true);
        locked = true;
    }
    public void UnlockReturn()
    {
        returnButton.interactable = true;
        canceller.SetActive(false);
        locked = false;
    }
}