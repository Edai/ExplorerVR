using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource audioSource;

    public void StopPlaying()
    {
        this.audioSource.Stop();
    }

    public void PlaySound(AudioClip clip)
    {
        this.audioSource.Stop();
        audioSource.volume = 1.0f;
        audioSource.loop = true;
        audioSource.PlayOneShot(clip);
    }

    internal void AddSound(AudioClip audioClip)
    {
        audioSource.volume = 1.0f;
        audioSource.loop = true;
        audioSource.PlayOneShot(audioClip);
    }
}
