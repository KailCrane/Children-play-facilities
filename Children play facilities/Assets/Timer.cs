using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public float total_time;

    public Text total_time_textbox;
    public Text curr_time_textbox;

    public void Setting(float _total_time)
    {
        total_time = _total_time;
        int min;
        int sec;
        min = Convert.ToInt32(total_time / 60);
        sec = Convert.ToInt32(total_time % 60);
        if (min < 10 && sec >= 10)
        {
            total_time_textbox.text = $"0{min}:{sec}";
        }
        else if (min < 10 && sec < 10)
        {
            total_time_textbox.text = $"0{min}:0{sec}";
        }
        else if (min >= 10 && sec < 10)
        {
            total_time_textbox.text = $"{min}:0{sec}";
        }
        else if (min >= 10 && sec >= 10)
        {
            total_time_textbox.text = $"{min}:{sec}";
        }
    }

    public void VisualShow(float _curr_time)
    {
        int min;
        int sec;
        min = Convert.ToInt32(_curr_time / 60);
        sec = Convert.ToInt32(_curr_time % 60);

        if (min < 10 && sec >= 10)
        {
            curr_time_textbox.text = $"0{min}:{sec}";
        }
        else if (min < 10 && sec < 10)
        {
            curr_time_textbox.text = $"0{min}:0{sec}";
        }
        else if (min >= 10 && sec < 10)
        {
            curr_time_textbox.text = $"{min}:0{sec}";
        }
        else if (min >= 10 && sec >= 10)
        {
            curr_time_textbox.text = $"{min}:{sec}";
        }
    }
}
