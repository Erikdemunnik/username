using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleacherPersonAnim : MonoBehaviour
{
    public Animator anim;
    float animStart;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animStart = Random.Range(0f, 10f);
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        animStart = animStart - 1 * Time.deltaTime;
        if (animStart < 0)
        {
            animStarted();
        }
    }
    void animStarted()
    {
        anim.enabled = true;
    }
}
