using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    InventoryManager inventory;
    public Item item;
    bool isCollectable = false;

    private void Start()
    {
        inventory = InventoryManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            isCollectable = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            isCollectable = false;
    }

    void OnMouseDown()
    {
        if (isCollectable)
        {
            inventory.Add(item);
            Destroy(gameObject);
        }
    }

}
