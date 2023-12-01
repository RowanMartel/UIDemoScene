using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableRotateTween : MonoBehaviour
{
    [SerializeField] Vector3 startRot, endRot;
    [SerializeField] Ease easeingType;
    [SerializeField] bool resetOnEnable;
    [SerializeField] bool timeScaleIndependant;
    [SerializeField] float tweenTime;
    [SerializeField] float delay;
    float timer;
    bool finished;
    RectTransform rectTransform;

    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        finished = false;
        timer = 0;
        if (resetOnEnable)
            rectTransform.eulerAngles = startRot;
        Tween();
    }

    private void Update()
    {
        if (delay > 0 && !finished)
        {
            timer += Time.deltaTime;
            if (timer >= delay) Tween();
        }
    }

    void Tween()
    {
        if (delay > 0 && timer < delay) return;

        rectTransform = GetComponent<RectTransform>();
        rectTransform.localEulerAngles = startRot;
        if (rectTransform != false) DOTween.To(() => rectTransform.localEulerAngles, x => rectTransform.localEulerAngles = x, endRot, tweenTime).SetEase(easeingType).SetUpdate(timeScaleIndependant);
        finished = true;
    }
}