using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource player;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PublicVariables.instance.level == 2)
            playSoundOnPlayer(PathFollow.instance.sonidosAux[0]);
    }

    public void playSound(AudioSource a)
    {
        a.Play();
    }

    public void stopSound(AudioSource a)
    {
        a.Stop();
    }

    public void playSoundOnPlayer(AudioClip ac)
    {
        player.clip = ac;
        player.Play();
    }
}
