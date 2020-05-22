using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotReceiver : MonoBehaviour
{

    [Tooltip("Distancia a la que se puede reaccionar al disparo")]
    [SerializeField] private float distanceToBeShot;

    private bool isShot = false;

    public void Receive()
    {
        if ((transform.position - Camera.main.transform.position).magnitude < distanceToBeShot)
            isShot = true;
    }

    public bool IsShot()
    {
        return isShot;
    }

    public void AlreadyShot()
    {
        isShot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToBeShot);
    }

}
