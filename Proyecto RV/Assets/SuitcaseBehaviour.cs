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
            // ...
            pd.Play();
            sr.AlreadyShot();
            gameObject.SetActive(false);
        }
    }

}
