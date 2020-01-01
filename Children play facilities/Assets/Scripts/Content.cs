using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    public float apear_time;
    public float disapear_time;
    public Text textbox;

    public Vector2 pos;

    public enum Type {Picture,Video,Text,Audio,Quiz}
    public Type type;
    private VideoPlayer vp;

    private MainCtrl mainctrl;

    private AudioSource _audio;
    public AudioClip clip;
    private Speaker sp;


    public void Start()
    {
        sp = Speaker.instance;
        mainctrl = MainCtrl.instance;
        _audio = GetComponent<AudioSource>();
        MainCtrl.OnPause += Pause;
        MainCtrl.OnPlay += Play;
    }

    public void Update()
    {
        if(_audio != null)
        {
            _audio.volume = sp.volume_slider.value;
        }
    }


    public void Pause()
    {
        switch(type)
        {
            case Type.Audio:
                _audio.Pause();
                break;
            case Type.Video:
                vp.Stop();
                break;
        }
    }

    public void Play()
    {
        switch (type)
        {
            case Type.Audio:
                _audio.UnPause();
                break;
            case Type.Video:
                vp.Play();
                break;
        }
    }
}
