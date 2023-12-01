using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableScaleTween : MonoBehaviour
{
    [SerializeField] Vector3 startScale, endScale;
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
            rectTransform.localScale = startScale;
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
        rectTransform.localScale = startScale;
        if (rectTransform != false) DOTween.To(() => rectTransform.localScale, x => rectTransform.localScale = x, endScale, tweenTime).SetEase(easeingType).SetUpdate(timeScaleIndependant);
        finished = true;
    }
}