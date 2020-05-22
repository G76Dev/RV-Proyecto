using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehaviour : MonoBehaviour
{

    [Tooltip("Referencia al sistema de partículas del arma.")]
    [SerializeField] private ParticleSystem particles;

    [Tooltip("Referencia al animator de la pistola.")]
    [SerializeField] private Animator anim;

    [Tooltip("Rotación a partir de la cual se puede cambiar de modo (caminar / disparar).")]
    [SerializeField] private float rotLimit = 0.4f;
    
    [Tooltip("Referencia al gameobject que agrupa todos los marcadores de desplazamiento.")]
    [SerializeField] private GameObject moveMarkers; // Asignar previamente en la escena de Unity.

    [Tooltip("Referencia al audio source del sonido de disparo.")]
    [SerializeField] private AudioSource sound;

    private bool canShoot = false;
    private bool alreadyChanged = false;

    public void PlayParticlesAndSound()
    {
        particles.Play();
        sound.Play();
    }

    public void CanShoot()
    {
        canShoot = true;
    }

    public void CannotShoot()
    {
        canShoot = false;
    }

    public void ActivateMarkers()
    {
        if (PathFollow.instance.actualMarker != -1)
        {
            foreach (int num in PathFollow.instance.virtualMarkers[PathFollow.instance.actualMarker].marcadoresAlrededor)
            {
                if (PathFollow.instance.virtualMarkers[num].isSphere)
                    PathFollow.instance.virtualMarkers[num].gameObject.SetActive(true);
                else
                    PathFollow.instance.virtualMarkers[num].collider.enabled = true;
            }
        }
        else
        {
            PathFollow.instance.virtualMarkers[0].collider.enabled = true;
        }
    }

    public void DeactivateMarkers()
    {
        foreach (VirtualMarker vm in PathFollow.instance.virtualMarkers)
        {
            if (vm.isSphere && vm.gameObject.activeSelf)
            {
                vm.gameObject.SetActive(false);
            }
            else if (vm.collider.enabled && !vm.isSphere)
            {
                vm.collider.enabled = false;
            }
        }
    }

    public void PlayShotSound()
    {
        sound.Play();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            anim.Play("Pistol_Shot");
            RaycastHit rh;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rh))
            {
                ShotReceiver sr = rh.collider.gameObject.GetComponent<ShotReceiver>();
                if (sr != null)
                    sr.Receive();
            }
        }
    }

    private void Update()
    {
        if (!alreadyChanged)
        {
            if (transform.parent.rotation.x > rotLimit)
            {
                alreadyChanged = true;
                anim.Play(canShoot ? "Pistol_Hiding" : "Pistol_Appearing");
            }
        }
        else if (transform.parent.rotation.x <= rotLimit)
        {
            alreadyChanged = false;
        }
    }

}
