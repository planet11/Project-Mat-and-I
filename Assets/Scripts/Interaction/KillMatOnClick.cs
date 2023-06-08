using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMatOnClick : MonoBehaviour
{
    public GameObject mat;

    public void WhenClicked()
    {
        if (mat.activeInHierarchy == true)
        {
            mat.SetActive(false);
        }
        else
        {
            mat.SetActive(true);
        }
    }
}


