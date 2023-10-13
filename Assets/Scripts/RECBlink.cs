using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RECBlink : MonoBehaviour
{
    float timer = 0;
    [SerializeField] float blinkTime;
    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        BlinkTimer();
    }

    void BlinkTimer()
    {
        timer += Time.deltaTime;
        if (timer >= blinkTime)
        {
            if (text.enabled) text.enabled = false;
            else text.enabled = true;
            timer = 0;
        }
    }
}