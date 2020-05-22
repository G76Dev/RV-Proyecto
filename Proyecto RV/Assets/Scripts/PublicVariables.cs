using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVariables : MonoBehaviour
{
    public static PublicVariables instance;

    public int level;

    public GameObject carnet;
    public GameObject periodico;
    public GameObject llaves;
    public GameObject pistola;
    public GameObject nota;

    public bool pistolaTaken;

    public GameObject puerta1;
    public GameObject puerta2;
    public GameObject puerta3;
    public GameObject puerta4;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateCarnet()
    {
        Destroy(carnet);
        PathFollow.instance.virtualMarkers[0].marcadoresAlrededor.Add(2);
        PathFollow.instance.virtualMarkers[1].marcadoresAlrededor.Add(2);
        PathFollow.instance.virtualMarkers[2].collider.enabled = true;

        puerta1.GetComponent<AudioSource>().Play();
        puerta1.transform.RotateAround(new Vector3(-35.36132f, 1.325f, 27.038f), Vector3.up, 90);

        AudioManager.instance.playSoundOnJugador(PathFollow.instance.sonidosDialogos[10]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[10], PathFollow.instance.sonidosDialogos[1]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[10], PathFollow.instance.sonidosDialogos[1], PathFollow.instance.sonidosDialogos[2]);
    }

    public void UpdatePeriodico()
    {
        Destroy(periodico);
        PathFollow.instance.virtualMarkers[4].marcadoresAlrededor.Add(6);
        PathFollow.instance.virtualMarkers[5].marcadoresAlrededor.Add(6);
        PathFollow.instance.virtualMarkers[6].collider.enabled = true;

        puerta2.GetComponent<AudioSource>().Play();
        puerta2.transform.RotateAround(new Vector3(-56.463f, 1.325f, 30.488f), Vector3.up, 90);

        AudioManager.instance.playSoundOnJugador(PathFollow.instance.sonidosDialogos[4]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[4], PathFollow.instance.sonidosDialogos[13]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[4], PathFollow.instance.sonidosDialogos[13], PathFollow.instance.sonidosDialogos[14]);
        Invoke("noEncuentraLlaves1", 60f);
    }

    public void UpdatePistola()
    {
        Destroy(pistola);
        pistolaTaken = true;
    }

    public void UpdateLlaves()
    {
        if (pistolaTaken)
        {
            Destroy(llaves);
            PathFollow.instance.virtualMarkers[7].marcadoresAlrededor.Add(9);
            PathFollow.instance.virtualMarkers[9].collider.enabled = true;

            AudioManager.instance.playSoundOnPlayer(PathFollow.instance.sonidosAux[1]);
            puerta3.GetComponent<AudioSource>().Play();
            puerta3.transform.RotateAround(new Vector3(-71.36f, 1.325f, 29.19f), Vector3.up, -80);
        }
    }

    public void UpdateNota()
    {
        Destroy(nota.transform.parent.gameObject);
        PathFollow.instance.interactableObjects[5].collider.enabled = true;

        puerta4.GetComponent<AudioSource>().Play();
        puerta4.transform.Rotate(Vector3.up, 60);

        AudioManager.instance.playSoundOnJugador(PathFollow.instance.sonidosDialogos[11]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[10], PathFollow.instance.sonidosDialogos[8]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[10], PathFollow.instance.sonidosDialogos[8], PathFollow.instance.sonidosDialogos[15]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[10], PathFollow.instance.sonidosDialogos[8], PathFollow.instance.sonidosDialogos[15], PathFollow.instance.sonidosDialogos[16]);
        AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[10], PathFollow.instance.sonidosDialogos[8], PathFollow.instance.sonidosDialogos[15], PathFollow.instance.sonidosDialogos[16], PathFollow.instance.sonidosDialogos[9]);
    }

    public void noEncuentraLlaves1()
    {
        if (PathFollow.instance.interactableObjects[3] != null)
        {
            AudioManager.instance.playSoundOnJugador(PathFollow.instance.sonidosDialogos[6]);
            Invoke("noEncuentraLlaves2", PathFollow.instance.sonidosDialogos[6].length + 0.5f);
        }
    }

    public void noEncuentraLlaves2()
    {
        if (PathFollow.instance.interactableObjects[3] != null)
        {
            AudioManager.instance.playSoundOnJugador(PathFollow.instance.sonidosDialogos[7]);
        }
    }

    public void EndLevel()
    {
        LevelChanger.instance.FadeToLevel(level + 1, 0);
    }

}
