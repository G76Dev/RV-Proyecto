using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }
}
