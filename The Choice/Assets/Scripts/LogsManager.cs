using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LogsManager : MonoBehaviour
{
    public List<VideoPlayer> vPlayers;
    public GameObject canvas;
    private VideoPlayer video;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CheckPlayer();
        turnOffAfterPlay(video);
    }

    public void CheckPlayer()
    {
        foreach (VideoPlayer p in vPlayers)
        {
            if (p.isPlaying)
            {
                Cursor.lockState = CursorLockMode.Locked;
                canvas.SetActive(false);
                video = p;
                return;
            }
        } 
    }

    public void turnOffAfterPlay(VideoPlayer v)
    {
        if (v != null)
        {
            if (!v.isPlaying)
            {
                v.enabled = false;
                video = null;
                Cursor.lockState = CursorLockMode.None;
                canvas.SetActive(true);
            }
        }
    }
}
