using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progress_bar;

    private float total_time;

    public void Setting(float _total_time)
    {
        total_time = _total_time;
    }

    public void VisualShow(float _curr_time)
    {
        progress_bar.value = (float)_curr_time / (float)total_time;
    }
}
