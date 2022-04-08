using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillMeter : MonoBehaviour
{
    private float ratio;

    public Image meter;

    private void Start()
    {
        if (!meter) meter = GetComponent<Image>();
    }

    public void SetRatio(float f)
    {
        ratio = f;
        meter.fillAmount = f;
    }
}
