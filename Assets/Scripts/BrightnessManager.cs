using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessManager : MonoBehaviour
{
    [SerializeField] PostProcessProfile brightness;
    [SerializeField] PostProcessLayer layer;
    AutoExposure exposure;

    void Start()
    {
        brightness.TryGetSettings(out exposure);
    }

    public void SetBrightness(float value)
    {
        exposure.keyValue.value = value;
    }
}