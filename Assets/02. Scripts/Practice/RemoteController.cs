using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    VideoPlayer videoPlayer;
    
    public Button[] buttonUI;
    public VideoClip[] clips;

    private bool isOn = false;
    private bool isMute = false;
    private int currClipIndex = 0;

    void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[currClipIndex]; // Default 영상 설정
    }
    

    void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(()=>OnChangeChannel(false));
        buttonUI[3].onClick.AddListener(()=>OnChangeChannel(true));
    }

    public void OnScreenPower()
    {
        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);
        // videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    public void OnPrevChannel()
    {
        currClipIndex = (currClipIndex - 1 + clips.Length) % clips.Length;
        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
    
    public void OnNextChannel()
    {
        currClipIndex = (currClipIndex + 1) % clips.Length;
        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnChangeChannel(bool isNext)
    {
        if (isNext)
            currClipIndex = (currClipIndex + 1) % clips.Length;
        else
            currClipIndex = (currClipIndex - 1 + clips.Length) % clips.Length;
        
        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
    
}
