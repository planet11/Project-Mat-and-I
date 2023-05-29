using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Inventory inventory;
    public Item item;

    void OnMouseDown()
    {
        if (Inventory.instance.Add(item))
        {
            Destroy(gameObject);
        }
    }

}
