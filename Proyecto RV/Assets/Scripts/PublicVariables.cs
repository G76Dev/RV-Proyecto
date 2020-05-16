using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVariables : MonoBehaviour
{
    public static PublicVariables instance;

    public GameObject carnet;
    public GameObject periodico;
    public GameObject llaves;
    public GameObject pistola;

    public bool pistolaTaken;

    public GameObject puerta1;
    public GameObject puerta2;
    public GameObject puerta3;

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

        puerta1.transform.RotateAround(new Vector3(-35.36132f, 1.325f, 27.038f), Vector3.up, 90);
    }

    public void UpdatePeriodico()
    {
        Destroy(periodico);
        PathFollow.instance.virtualMarkers[4].marcadoresAlrededor.Add(6);
        PathFollow.instance.virtualMarkers[5].marcadoresAlrededor.Add(6);
        PathFollow.instance.virtualMarkers[6].collider.enabled = true;

        puerta2.transform.RotateAround(new Vector3(-56.463f, 1.325f, 30.488f), Vector3.up, 90);
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

            puerta3.transform.RotateAround(new Vector3(-71.36f, 1.325f, 29.19f), Vector3.up, -80);
        }
    }

    public void EndLevel()
    {
        LevelChanger.instance.FadeToLevel(1, 0);
    }

}
