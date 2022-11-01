using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    public UnityEvent onEnd;
    public GameObject Video;
    public VideoPlayer Player;

    // Start is called before the first frame update
    void Start()
    {
        Player.loopPointReached += SendToNextScene_loopPointReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SendToNextScene_loopPointReached(VideoPlayer source)
    {
        SceneManager.LoadScene(1);
    }
}
