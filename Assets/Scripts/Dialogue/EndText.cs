using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndText : MonoBehaviour
{
    public TMP_Text endText01;
    public TMP_Text endText02;
    public TMP_Text endText03;

    public Button contBtn01;
    public Button contBtn02;
    public Button endBtn;

    public Button backBtn01;
    public Button backBtn02;

    private void Awake()
    {
        endText01.enabled = false;
        endText02.enabled = false;
        endText03.enabled = false;

        contBtn01.gameObject.SetActive(false);
        contBtn02.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(false);

        backBtn01.gameObject.SetActive(false);
        backBtn02.gameObject.SetActive(false);
    }

    private void Start()
    {
        PageOne();
    }

    public void PageOne()
    {
        endText01.enabled = true;
        endText02.enabled = false;
        endText03.enabled = false;

        contBtn01.gameObject.SetActive(true);
        contBtn02.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(false);

        backBtn01.gameObject.SetActive(false);
        backBtn02.gameObject.SetActive(false);
    }

    public void PageTwo()
    {
        endText01.enabled = false;
        endText02.enabled = true;
        endText03.enabled = false;

        contBtn01.gameObject.SetActive(false);
        contBtn02.gameObject.SetActive(true);
        endBtn.gameObject.SetActive(false);

        backBtn01.gameObject.SetActive(true);
        backBtn02.gameObject.SetActive(false);
    }

    public void PageThree()
    {
        endText01.enabled = false;
        endText02.enabled = false;
        endText03.enabled = true;

        contBtn01.gameObject.SetActive(false);
        contBtn02.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(true);

        backBtn01.gameObject.SetActive(false);
        backBtn02.gameObject.SetActive(true);
    }
}
