using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSquishTween : MonoBehaviour, IPointerEnterHandler
{
    Button button;
    Vector3 startScale;
    Vector3 endScale;
    RectTransform rectTransform;
    [SerializeField][Range(0, 100)] float squishPercent;

    [Header("True: Squishes on hover. False: Squishes on click")]
    [SerializeField] bool onHover;

    void Start()
    {
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();
        startScale = rectTransform.localScale;
        endScale = rectTransform.localScale * ((100 - squishPercent) / 100);
        if (!onHover) button.onClick.AddListener(Squish);
    }

    void Squish()
    {
        Debug.Log("Squishing from " + startScale + " to " + endScale);

        endScale = rectTransform.localScale * ((100 - squishPercent) / 100);
        rectTransform.localScale = startScale;

        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(DOTween.To(() => rectTransform.localScale, x => rectTransform.localScale = x, endScale, .075f).SetEase(Ease.InOutSine).SetUpdate(true));
        sequence.Append(DOTween.To(() => rectTransform.localScale, x => rectTransform.localScale = x, startScale, .075f).SetEase(Ease.InOutSine).SetUpdate(true));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (onHover) Squish();
    }
}