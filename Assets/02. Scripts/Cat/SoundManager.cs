using System;
using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip bgmClip;
        public AudioClip jumpClip;
        public AudioClip introBGMClip;
        public AudioClip pickupClip;

        public void SetBGMSound(string bgmName)
        {
            if (bgmName == "Intro")
                audioSource.clip = introBGMClip;
            else if (bgmName == "Play")
                audioSource.clip = bgmClip;
            
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            audioSource.volume = 0.1f;
            
            audioSource.Play();
        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(pickupClip);
        }
        
    }
}