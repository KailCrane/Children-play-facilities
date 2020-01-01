using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundPlayer : MonoBehaviour
{
    private AudioSource audio;

    public List<AudioClip> audioClips = new List<AudioClip>();

    public void PlaySound(string _name)
    {
        for (int i = 0; i < audioClips.Count; i++)
        {
            if (audioClips[i].name == _name)
            {
                audio.PlayOneShot(audioClips[i]);
            }
        }
    }

    public bool PlayCheck()
    {
        if (audio.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
