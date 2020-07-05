using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMarker : MonoBehaviour
{
    public Collider collider;

    public bool isSphere;
    public List<int> marcadoresAlrededor = new List<int>();

    void Start()
    {
        collider = GetComponent<Collider>();
    }
}