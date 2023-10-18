using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMouth : Singleton<AudioMouth>
{
    public AudioSource _audioSource;
    public AudioClip audioClip;

    public bool _mouthAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audioClip;
        _mouthAudioPlayed = false;
    }

    public void playMouthAudio()
    {
        if (!_audioSource.isPlaying && _mouthAudioPlayed == false)
        {
            _audioSource.Play();
            _mouthAudioPlayed = true;
        }
    }
}
