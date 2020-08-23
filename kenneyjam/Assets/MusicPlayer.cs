using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] Clips;
    public AudioClip ButtonClickClip;
    private static MusicPlayer _instance;
    private static AudioSource _audioSource;
    private static AudioSource _audioSource2;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            var aSources = this.GetComponents<AudioSource>();
            _audioSource = aSources[0];
            _audioSource2 = aSources[1];
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            PlayMainMenuMusic();
            Destroy(gameObject);
        }
    }

    public void PlayMainMenuMusic()
    {
        PlayMusicIfNotAlready(Clips[0]);
    }

    public void PlayGameplayMusic()
    {
        PlayMusicIfNotAlready(Clips[1]);
    }

    public void PlayGameOverMusic()
    {
        PlayMusicIfNotAlready(Clips[2]);
    }

    public void PlayButtonClickClip()
    {
        _audioSource2.clip = ButtonClickClip;
        _audioSource2.Play();
    }

    public void PlayMusicIfNotAlready(AudioClip clip)
    {
        if (_audioSource.clip != clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
