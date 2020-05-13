using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public static ZoomIn instance;
    public bool zooming;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (zooming)
        {
            transform.localScale = new Vector3(transform.localScale.x + (1.0f * Time.deltaTime), transform.localScale.y + (1.0f * Time.deltaTime), 1.0f);
        }
    }
}
