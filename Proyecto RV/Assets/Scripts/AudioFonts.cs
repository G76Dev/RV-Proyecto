using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFonts : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1f;
    }

    public void playSound(AudioClip a)
    {
        audioSource.clip = a;
        audioSource.Play();
    }

    public void stopSound()
    {
        audioSource.Stop();
    }
}
