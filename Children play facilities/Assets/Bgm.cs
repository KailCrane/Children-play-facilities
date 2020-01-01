using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    AudioSource _audio;
    Speaker sp;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        sp = Speaker.instance;

    }

    // Update is called once per frame
    void Update()
    {
        _audio.volume = sp.volume_slider.value;
    }
}
