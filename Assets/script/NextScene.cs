using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NextScene : MonoBehaviour
{
    VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();

        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;

        Invoke("play", 1);
    }

    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        SceneManager.LoadScene(3);
    }

    private void play()
    {
        videoPlayer.Play();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) | Input.GetKeyUp(KeyCode.Return))
            SceneManager.LoadScene(3);

    }
}