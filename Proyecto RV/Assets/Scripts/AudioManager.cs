using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource player;
    public AudioSource jugador;
    public AudioSource narrador;
    public bool radioDialogo;
    public bool llavesDialogo;
    public bool periodicoDialogo;

    private AudioClip secondClipJugador;
    private AudioClip thirdClipJugador;
    private AudioClip fourthClipJugador;
    private AudioClip fifthClipJugador;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PublicVariables.instance.level == 1)
            playSoundOnPlayer(PathFollow.instance.sonidosDialogos[0]);
        else if (PublicVariables.instance.level == 2)
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
        //Debug.Log("sonido player: " + ac.name);
        player.clip = ac;
        player.Play();
    }

    public void playSoundOnJugador(AudioClip ac)
    {
        Debug.Log("sonido: " + ac.name);
        jugador.clip = ac;
        jugador.Play();
    }

    public void playAfter(AudioClip ac1, AudioClip ac2)
    {
        float duration = ac1.length;
        secondClipJugador = ac2;
        Invoke("SecondSoundJugador", duration + 1f);
    }

    public void playAfter(AudioClip ac11, AudioClip ac12, AudioClip ac2)
    {
        float duration = ac11.length + ac12.length;
        thirdClipJugador = ac2;
        Invoke("ThirdSoundJugador", duration + 2f);
    }

    public void playAfter(AudioClip ac11, AudioClip ac12, AudioClip ac13, AudioClip ac2)
    {
        float duration = ac11.length + ac12.length + ac13.length;
        fourthClipJugador = ac2;
        Invoke("FourthSoundJugador", duration + 2f);

    }

    public void playAfter(AudioClip ac11, AudioClip ac12, AudioClip ac13, AudioClip ac14, AudioClip ac2)
    {
        float duration = ac11.length + ac12.length + ac13.length + ac14.length;
        fifthClipJugador = ac2;
        Invoke("FifthSoundJugador", duration + 2f);
    }

    public void SecondSoundJugador()
    {
        if (!jugador.isPlaying)
        {
            jugador.clip = secondClipJugador;
            jugador.Play();
            Debug.Log("sonido: " + secondClipJugador.name);
        }
        else
        {
            Debug.LogWarning("Can't play " + secondClipJugador.name +  ". This song is already playing: " + jugador.clip.name);
        }
    }

    public void ThirdSoundJugador()
    {
        if (!jugador.isPlaying)
        {
            jugador.clip = thirdClipJugador;
            jugador.Play();
            Debug.Log("sonido: " + thirdClipJugador.name);
        }
        else
        {
            Debug.LogWarning("Can't play " + thirdClipJugador.name + ". This song is already playing: " + jugador.clip.name);
        }
    }

    public void FourthSoundJugador()
    {
        if (!jugador.isPlaying)
        {
            jugador.clip = fourthClipJugador;
            jugador.Play();
            Debug.Log("sonido: " + fourthClipJugador.name);
        }
        else
        {
            Debug.LogWarning("Can't play " + fourthClipJugador.name + ". This song is already playing: " + jugador.clip.name);
        }
    }

    public void FifthSoundJugador()
    {
        if (!jugador.isPlaying)
        {
            jugador.clip = fifthClipJugador;
            jugador.Play();
            Debug.Log("sonido: " + fifthClipJugador.name);
        }
        else
        {
            Debug.LogWarning("Can't play " + fifthClipJugador.name + ". This song is already playing: " + jugador.clip.name);
        }
    }

    public void tieneQueApagarla(AudioClip ac)
    {
        if (!radioDialogo)
        {
            radioDialogo = true;
            AudioManager.instance.playSoundOnPlayer(ac);
        }
    }

    public void tieneQueCogerlas(AudioClip ac)
    {
        if (!llavesDialogo)
        {
            llavesDialogo = true;
            AudioManager.instance.playSoundOnJugador(ac);
        }
    }

    public void tieneQueLeerlo(AudioClip ac)
    {
        if (!periodicoDialogo)
        {
            periodicoDialogo = true;
            AudioManager.instance.playSoundOnJugador(ac);
        }
    }
}
