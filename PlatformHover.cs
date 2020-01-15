using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHover : MonoBehaviour
{
    Rigidbody platform;
    float freezeX;
    float freezeZ;

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Rigidbody>();
        platform.freezeRotation = true;
        freezeX = platform.transform.position.x;
        freezeZ = platform.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(freezeX, 5 + (Mathf.Sin(Time.time * 2) *2), freezeZ);
    }
}
