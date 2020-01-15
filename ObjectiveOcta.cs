using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOcta : MonoBehaviour
{
    public Transform Octa1;
    public Rigidbody trigger;
    public Transform floorGlow;

    void Start()
    {
        trigger.freezeRotation = true;
        //trigger.AddForce(0, 500, 0);
    }

    void Update()
    {
        //z-as lock
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //objective zweeft op en neer met een sine wave
        Octa1.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y + 1 + (Mathf.Sin(Time.time * 2.0f) * 0.6f), trigger.transform.position.z);
        //glowy cirkel op de grond onder objective
        floorGlow.position = new Vector3(trigger.position.x,0.05f, trigger.position.z);
        //object draait rond
        Octa1.Rotate(0, Time.deltaTime * 300, 0);
    }
}
