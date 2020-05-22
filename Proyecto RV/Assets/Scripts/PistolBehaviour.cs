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

    private List<VirtualMarker> marcadoresActivos;

    private void Awake()
    {
        marcadoresActivos = new List<VirtualMarker>();
    }

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
        foreach (VirtualMarker vm in marcadoresActivos)
        {
            if (vm.isSphere)
                vm.gameObject.SetActive(true);
            else
                vm.collider.enabled = true;
        }

        marcadoresActivos.Clear();
        
    }

    public void DeactivateMarkers()
    {
        foreach (VirtualMarker vm in PathFollow.instance.virtualMarkers)
        {
            if (vm.isSphere && vm.gameObject.activeSelf)
            {
                marcadoresActivos.Add(vm);
                vm.gameObject.SetActive(false);
            }
            else if (vm.collider.enabled)
            {
                marcadoresActivos.Add(vm);
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
