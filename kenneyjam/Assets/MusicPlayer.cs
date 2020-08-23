using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] Clips;
    private static MusicPlayer _instance;
    private static AudioSource _audioSource;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _audioSource = this.GetComponent<AudioSource>();
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

    public void PlayMusicIfNotAlready(AudioClip clip)
    {
        if (_audioSource.clip != clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
