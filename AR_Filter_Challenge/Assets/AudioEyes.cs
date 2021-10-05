using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEyes : Singleton<AudioEyes>
{
    public AudioSource _audioSource;
    public AudioClip audioClip;

    private bool _eyesAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audioClip;
        _eyesAudioPlayed = false;
    }

    public void playEyesAudio()
    {
        if (!_audioSource.isPlaying && _eyesAudioPlayed == false)
        {
            _audioSource.Play();
            _eyesAudioPlayed = true;
        }
    }
}