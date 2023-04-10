using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    void OnMouseDown()
    {
        Debug.Log("Got " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }

}
