using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class video_stand : UnityEngine.MonoBehaviour
{

    public VideoClip videoClip;
    private VideoPlayer vidPlayer;
    private void Awake()
    {
        vidPlayer = gameObject.GetComponentInChildren<VideoPlayer>();
    }
    void Start()
    {
        vidPlayer.clip = videoClip;
        vidPlayer.Play();
    }

}
