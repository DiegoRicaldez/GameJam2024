using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public string siguienteScena = "Juego";
    public VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
                SceneManager.LoadScene(siguienteScena);
            }
        }
    }

    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(siguienteScena);
    }
}
