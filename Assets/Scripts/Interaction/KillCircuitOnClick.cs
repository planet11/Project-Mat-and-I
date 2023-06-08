using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCircuitOnClick : MonoBehaviour
{
    public GameObject circuit;

    public void WhenClicked()
    {
        if (circuit.activeInHierarchy == true)
        {
            circuit.SetActive(false);
        }
        else
        {
            circuit.SetActive(true);
        }
    }
}

