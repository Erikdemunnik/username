using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveRelease : MonoBehaviour
{
    float dropTimer;
    Collider col;
    ParticleSystem beam;
    public ParticleSystem splode;

    // Start is called before the first frame update
    void Start()
    {
        dropTimer = 0;
        col = gameObject.GetComponent<Collider>();
        beam = GetComponent<ParticleSystem>();
        splode.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        dropTimer += 1 * Time.deltaTime;

        if (dropTimer > 10)
        {
            col.enabled = false;
            beam.Stop();
        }
        if (dropTimer > 10 && dropTimer < 11)
        {
            Kaboom();
        }
    }
    void Kaboom()
    {
        splode.Play();
    }
}
