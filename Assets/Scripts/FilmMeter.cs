using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FilmMeter : MonoBehaviour
{
    public float fillAmount;
    public event EventHandler<FilmMeterChangedEventArgs> FilmMeterChanged;
    Image filmRollImg;
    TMP_Text count;

    private void Start()
    {
        count = GetComponentInChildren<TMP_Text>();
        filmRollImg = GetComponent<Image>();
        ResetMeter();
    }

    public void ResetMeter()
    {
        filmRollImg.fillAmount = 0;
        fillAmount = 0;
        count.text = "0/8";
    }

    public void FillMeter(float amount)
    {
        fillAmount += amount;
        if (fillAmount > 1) fillAmount = 1;
        filmRollImg.fillAmount = fillAmount;
        count.text = (fillAmount * 8).ToString() + "/8";
        FilmMeterChanged?.Invoke(this, new FilmMeterChangedEventArgs(fillAmount));
    }
}

public class FilmMeterChangedEventArgs : EventArgs
{
    public float fillAmount;

    public FilmMeterChangedEventArgs(float fillAmount)
    { this.fillAmount = fillAmount; }
}