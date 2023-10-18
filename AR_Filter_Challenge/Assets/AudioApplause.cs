using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioApplause : Singleton<AudioApplause>
{
    public AudioSource _audioSource;
    public AudioClip audioClip;

    public bool _applauseAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audioClip;
        _applauseAudioPlayed = false;
    }

    public void playApplauseAudio()
    {
        if (!_audioSource.isPlaying && _applauseAudioPlayed == false)
        {
            _audioSource.Play();
            _applauseAudioPlayed = true;
        }
    }
}
