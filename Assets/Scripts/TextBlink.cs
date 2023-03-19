using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    public float blinkFadeIn = 0.3f;
    public float blinkStay = 0.5f;
    public float blinkFadeOut = 0.4f;
    private float timeCheck = 0;

    Text blinkText;
    private Color color;

    void Start()
    {
        blinkText = GetComponent<Text>();
        color = blinkText.color;
    }

    void Update()
    {
        timeCheck += Time.deltaTime;

        if (timeCheck < blinkFadeIn)
        {
            blinkText.color = new Color(color.r, color.g, color.b, timeCheck/blinkFadeIn);
        }
        else if (timeCheck < blinkFadeIn + blinkStay)
        {
            blinkText.color = new Color(color.r, color.g, color.b, 1);
        }
        else if (timeCheck < blinkFadeIn + blinkStay + blinkFadeOut)
        {
            blinkText.color = new Color(color.r, color.g, color.b, (timeCheck - (blinkFadeIn + blinkStay)) / blinkFadeOut);
        }
        else
        {
            timeCheck = 0;
        }
    }
}
