using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFlicker : MonoBehaviour
{
    float random1;
    float random2;
    float random3;
    public Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        random1 = Random.Range(0.2f, 1);
        random2 = Random.Range(0.2f, 2);
        random3 = Random.Range(0.2f, 3);

    }

    // Update is called once per frame
    void Update()
    {

            float result1 = Mathf.Sin(Time.time * random1) * random2;
            float result2 = Mathf.Sin(Time.time * random2) * random3;
            float result3 = Mathf.Sin(Time.time * random3) * random1;
            lt.intensity = 5 + (1f *(result1 + result2 + result3 / 3));

        

    }
}
