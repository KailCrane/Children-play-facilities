using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressiveBar : MonoBehaviour
{
    Slider slider;

    public void Progress(float _value)
    {
        slider.value += _value;
    }
}
