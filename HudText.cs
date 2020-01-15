using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudText : MonoBehaviour
{
    Text m_MyText;
    float timing;
    float reset;
    public Image controls1;
    public Image controls2;
    Vector3 origPos;

    void Start()
    {
        timing = 0;
        controls1.enabled = true;
        controls2.enabled = true;
        m_MyText = GetComponent<Text>();
        m_MyText.text = "";
        origPos = transform.position;
    }


    void Update()
    {
        reset = (reset + 1 * Time.deltaTime);
        if (reset > 1)
        {
            transform.position = origPos;
            reset = 0;
            timing = timing + 1;
        }
        if (timing == 6)
        {
            m_MyText.text = "Get Ready!";
            controls1.enabled = false;
            controls2.enabled = false;
        }
        if (timing == 7)
        {
            m_MyText.text = "3";
        }
        if (timing == 8)
        {
            m_MyText.text = "2";
        }
        if (timing == 9)
        {
            m_MyText.text = "1";
        }
        if (timing == 10)
        {
            m_MyText.text = "Go!";
        }
        if (timing == 11)
        {
            m_MyText.text = "";
        }
    }
}
