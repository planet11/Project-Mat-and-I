using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndText : MonoBehaviour
{
    public TMP_Text endText01;
    public TMP_Text endText02;
    public TMP_Text endText03;
    public TMP_Text contText;

    private void Awake()
    {
        endText01.enabled = false;
        endText02.enabled = false;
        endText03.enabled = false;
    }

    public void PageOne()
    {
        endText01.enabled = true;
        endText02.enabled = false;
        endText03.enabled = false;

        contText.text = ">>> Continue";
    }

    public void PageTwo()
    {
        endText01.enabled = false;
        endText02.enabled = true;
        endText03.enabled = false;

        contText.text = ">>> Continue";
    }

    public void PageThree()
    {
        endText01.enabled = false;
        endText02.enabled = false;
        endText03.enabled = true;

        contText.text = "End";
    }
}
