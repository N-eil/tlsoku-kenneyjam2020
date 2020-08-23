using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip RunePlacementSound;
    public AudioClip DamageSound;
    public AudioClip DoorSound;

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

    public void PlayDoorSound()
    {
        _audioSource.clip = DoorSound;
        _audioSource.Play();
    }
}
