using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource eventAudio;

    [SerializeField] private AudioClip[] clips;

    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Toggle bgmMute;
    
    [SerializeField] private Slider eventVolume;
    [SerializeField] private Toggle eventMute;

    void Awake()
    {
        bgmVolume.value = bgmAudio.volume;
        eventVolume.value = eventAudio.volume;
        bgmMute.isOn = bgmAudio.mute;
        eventMute.isOn = bgmAudio.mute;
    }
    void Start()
    {
        BgmSoundPlay("Overworld");
        
        bgmVolume.onValueChanged.AddListener(OnBgmVolumeChanged);
        bgmMute.onValueChanged.AddListener(OnBgmMuteToggled);
        
        eventVolume.onValueChanged.AddListener(OnEventVolumeChanged);
        eventMute.onValueChanged.AddListener(OnEventMuteToggled);
    }

    public void BgmSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                bgmAudio.clip = clip;
                bgmAudio.Play();
                return;
            }
        }
        
        Debug.Log($"{clipName}을 찾지 못했습니다.");
    }

    public void EventSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                eventAudio.PlayOneShot(clip);
                return;
            }
        }
        
        Debug.Log($"{clipName}을 찾지 못했습니다.");
    }

    void OnBgmVolumeChanged(float volume)
    {
        bgmAudio.volume = volume;
    }
    void OnEventVolumeChanged(float volume)
    {
        eventAudio.volume = volume;
    }

    void OnBgmMuteToggled(bool isOn)
    {
        bgmAudio.mute = isOn;
    }
    void OnEventMuteToggled(bool isOn)
    {
        eventAudio.mute = isOn;
    }
}