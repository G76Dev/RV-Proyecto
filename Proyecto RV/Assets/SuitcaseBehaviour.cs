using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SuitcaseBehaviour : MonoBehaviour
{

    [Tooltip("Referencia al script 'ShotReceiver' del mismo game object")]
    [SerializeField] private ShotReceiver sr;

    [Tooltip("Referencia al Animator de Timeline del maletín")]
    [SerializeField] private PlayableDirector pd;

    private void Update()
    {
        if (sr.IsShot())
        {
            PathFollow.instance.virtualMarkers[0].marcadoresAlrededor.Add(1);
            AudioManager.instance.playSoundOnJugador(PathFollow.instance.sonidosDialogos[6]);
            AudioManager.instance.playAfter(PathFollow.instance.sonidosDialogos[6], PathFollow.instance.sonidosDialogos[3]);
            pd.Play();
            sr.AlreadyShot();
            gameObject.SetActive(false);
        }
    }

}
