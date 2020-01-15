using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 1f;
    Transform target;
    Vector3 flying;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Objective").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            targetswap();
        }
        flyingcontrol();
    }

    void flyingcontrol()
    {
        flying = new Vector3(target.position.x + (Mathf.Sin(Time.time * 0.5f) * 3f), target.position.y + 2 + (Mathf.Sin(Time.time * 1f) * 2f), target.position.z + 5);
        transform.position = Vector3.SmoothDamp(transform.position, flying, ref velocity, smoothTime);
        transform.LookAt(target);
    }
    void targetswap()
    {
        target = GameObject.Find("Objective").GetComponent<Transform>();
        flyingcontrol();
    }
}
