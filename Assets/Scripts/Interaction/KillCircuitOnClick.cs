using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCircuitOnClick : MonoBehaviour
{
    public GameObject circuit;
    //public bool isUsed = false;

    public void WhenClicked()
    {
        if (circuit.activeInHierarchy == true)
        {
            circuit.SetActive(false);
            InventoryUI.instance.ClearItem();
        }
        else
        {
            circuit.SetActive(true);
        }
    }
}

