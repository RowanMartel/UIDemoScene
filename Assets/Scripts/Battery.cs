using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    [SerializeField] Slider lifeSlider;
    GameManager gameManager;

    float ticker;
    float deathTimer;

    bool dead = false;

    [SerializeField] Animation deathAnimation;

    [SerializeField] Image fillImg;
    [SerializeField] Image borderImg;

    float blinkTimer = 0;
    [SerializeField] float blinkTime;

    private void Start()
    {
        lifeSlider.value = 100;
        gameManager = Singleton.instance.GetComponentInChildren<GameManager>();
    }

    public void ModifyLife(int amount)
    {
        lifeSlider.value += amount;
        if (lifeSlider.value <= 0)
            Die();
    }

    void Die()
    {
        if (dead) return;
        deathAnimation.Play();
        dead = true;
    }

    private void Update()
    {
        // battery drain timer
        ticker += Time.deltaTime;
        if (ticker >= 1)
        {
            ticker = 0;
            ModifyLife(-5);
        }

        // die after anim timer
        if (dead)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer >= .15f)
                gameManager.LoadScene(GameManager.Scenes.loseScreen);
        }

        BlinkTimer();
    }
    void BlinkTimer()
    {
        if (lifeSlider.value > 20)
        {
            fillImg.enabled = true;
            borderImg.enabled = true;
            return;
        }

        blinkTimer += Time.deltaTime;
        if (blinkTimer >= blinkTime)
        {
            if (fillImg.enabled)
            {
                fillImg.enabled = false;
                borderImg.enabled = false;
            }
            else
            {
                fillImg.enabled = true;
                borderImg.enabled = true;
            }
            blinkTimer = 0;
        }
    }
}