using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speaker : MonoBehaviour
{

    public Sprite slight_sound_icon;
    public Sprite roud_sound_icon;
    public Sprite mute_icon;

    public Button speaker_btn;
    private Image speaker_image;

    //음소거 직전의 수치
    private float pre_vol_value;
    public enum State {Unmute , mute};
    private State state;

    [Header("사운드 볼륨 정도")]
    public float sound_rate;

    public Slider volume_slider;
    public static Speaker instance;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        volume_slider.value = 1;
        pre_vol_value = 1;
        speaker_image = speaker_btn.gameObject.transform.GetChild(0).GetComponent<Image>();

        speaker_image.sprite = roud_sound_icon;
        state = State.Unmute;

        speaker_btn.onClick.AddListener(ButtonPress);
    }

    // Update is called once per frame
    void Update()
    {
        if (volume_slider.value * 100 > 0 && volume_slider.value * 100 <= 50)
        {
            speaker_image.sprite = slight_sound_icon;
        }
        else if (volume_slider.value * 100 > 50)
        {
            speaker_image.sprite = roud_sound_icon;
        }
        if (volume_slider.value == 0)
        {
            speaker_image.sprite = mute_icon;
            state = State.mute;
        }
        else
        {
            state = State.Unmute;
        }
    }

    public void ButtonPress()
    {
        if(state == State.mute)
        {
            UnMute();
            print("음소거 해제");
        }
        else
        {
            Mute();
            print("음소거");
        }
    }

    public void Mute()
    {
        pre_vol_value = volume_slider.value;
        volume_slider.value = 0;
    }

    public void UnMute()
    {
        volume_slider.value = pre_vol_value;
    }
}
