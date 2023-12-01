using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableMoveTween : MonoBehaviour
{
    [SerializeField] Vector2 startPos, endPos;
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
            rectTransform.anchoredPosition = startPos;
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
        rectTransform.anchoredPosition = startPos;
        if (rectTransform != false) DOTween.To(()=> rectTransform.anchoredPosition, x=> rectTransform.anchoredPosition = x, endPos, tweenTime).SetEase(easeingType).SetUpdate(timeScaleIndependant);
        finished = true;
    }
}