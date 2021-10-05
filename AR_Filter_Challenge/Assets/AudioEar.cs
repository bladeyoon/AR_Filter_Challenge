using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEar : Singleton<AudioEar>
{
    public AudioSource _audioSource;
    public AudioClip audioClip;

    private bool _earAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audioClip;
        _earAudioPlayed = false;
    }

    public void playEarAudio()
    {
        if (!_audioSource.isPlaying && _earAudioPlayed == false)
        {
            _audioSource.Play();
            _earAudioPlayed = true;
        }
    }
}
