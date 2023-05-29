using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void OnMouseDown()
    {
        if (InventoryManager.instance.Add(item))
        {
            gameObject.SetActive(false);
            GameManager.instance.isHammerPickedUp = true;
        }
    }

}
