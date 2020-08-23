using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip RunePlacementSound;
    public AudioClip DamageSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayRunePlacementSound()
    {
        _audioSource.clip = RunePlacementSound;
        _audioSource.Play();
    }

    public void PlayDamageSound()
    {
        _audioSource.clip = DamageSound;
        _audioSource.Play();
    }
}
