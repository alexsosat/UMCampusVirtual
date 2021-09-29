using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class trigger_video : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counter++;
            checkCounter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counter--;
            checkCounter();
        }
    }

    void checkCounter() {
        if (counter > 0)
        {
            videoPlayer.Play();
        }
        else {
            videoPlayer.Stop();
        }
    }
}
