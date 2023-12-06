using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RECBlink : MonoBehaviour
{
    [SerializeField] float blinkTime;
    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();

        StartCoroutine(BlinkCoroutine());
    }

    void Blink()
    {
        if (text.enabled) text.enabled = false;
        else text.enabled = true;
        StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        yield return new WaitForSecondsRealtime(blinkTime);
        Blink();
    }
}