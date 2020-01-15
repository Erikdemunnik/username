using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    float fading;
    Text teggst;
    Color colorz;
    
    // Start is called before the first frame update
    void Start()
    {
        teggst = GetComponent<Text>();
        colorz = new Color32(255, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        fading = Mathf.Sin(Time.time * 2f) * 0.5f + 0.5f;
        colorz.a = fading;
        teggst.color = colorz;
    }
}
