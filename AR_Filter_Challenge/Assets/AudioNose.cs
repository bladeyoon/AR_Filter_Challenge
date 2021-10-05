using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNose : Singleton<AudioNose>
{
    public AudioSource _audioSource;
    public AudioClip audioClip;

    private bool _noseAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audioClip;
        _noseAudioPlayed = false;
    }

    public void playNoseAudio()
    {
        if (!_audioSource.isPlaying && _noseAudioPlayed == false)
        {
            _audioSource.Play();
            _noseAudioPlayed = true;
        }
    }
}
