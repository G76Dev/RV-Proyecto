using PaperPlaneTools.AR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerHandlerT3 : MonoBehaviour
{
    private bool looking;
    private float timeToChange;

    void Update()
    {
        if (looking & timeToChange <= Time.time)
        {
            looking = false;
            ZoomIn.instance.zooming = true;
            PublicVariables.instance.EndLevel();
            gameObject.SetActive(false);
        }
    }

    public void startLooking()
    {
        timeToChange = Time.time + 2.0f;
        looking = true;
    }

    public void stopLooking()
    {
        looking = false;
    }
}
