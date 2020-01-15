using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionIntensity : MonoBehaviour
{
    public float colorState;
    Material mat1;
    Color rgba1;
    // Start is called before the first frame update
    void Start()
    {
        mat1 = GetComponent<Renderer>().material;
        rgba1 = new Color32(191,150,180,255);
    }

    // Update is called once per frame
    void Update()
    {
        colorState = (Mathf.Sin(Time.time * 2) * 1f) + 1f;
        rgba1.r =  0.5f + (1.8f * colorState);
        rgba1.g =  0.5f + (0.8f * colorState);
        rgba1.b =  0.5f + (1.4f * colorState);
        mat1.SetColor("_EmissionColor", rgba1);
    }
}
