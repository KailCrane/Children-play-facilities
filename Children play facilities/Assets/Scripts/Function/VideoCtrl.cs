using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoCtrl : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer = this.gameObject.AddComponent<VideoPlayer>();
        //videoPlayer.
    }

    public void Play()
    {
        videoPlayer.Play();
        //player.Play();
    }

    public void Pause()
    {
        videoPlayer.Pause();
        //player.Pause();
    }


    public void Stop()
    {
        videoPlayer.Stop();
    }

    public void Rewind()
    {
        videoPlayer.time -= 5f;
        //player.Rewind();
    }
}
