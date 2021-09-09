using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class trigger_video : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            videoPlayer.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            videoPlayer.Pause();
        }
    }
}
