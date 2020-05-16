using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private MeshRenderer renderer;
    public float maxOutlineWidth = 0.00001f;
    public Color OutlineColor;

    public Collider collider;
    private void Start()
    {
        OutlineColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        renderer = GetComponent<MeshRenderer>();
        maxOutlineWidth = 0.00001f;
        HideOutline();
        collider.enabled = false;
    }

    public void ShowOutline()
    {
        renderer.material.SetFloat("_Outline", maxOutlineWidth);
        renderer.material.SetColor("_OutlineColor", OutlineColor);
    }

    public void HideOutline()
    {
        renderer.material.SetFloat("_Outline", 0f);
    }
}
