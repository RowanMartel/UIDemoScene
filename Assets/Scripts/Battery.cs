using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    [SerializeField] Slider lifeSlider;
    GameManager gameManager;

    float ticker;

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
        gameManager.LoadScene(GameManager.Scenes.loseScreen);
    }

    private void Update()
    {
        ticker += Time.deltaTime;
        if (ticker >= 1)
        {
            ticker = 0;
            ModifyLife(-1);
        }
    }
}