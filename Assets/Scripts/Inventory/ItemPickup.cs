using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    bool isCollectable = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollectable = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollectable = false;
    }

    void OnMouseDown()
    {
        if (isCollectable && InventoryManager.instance.Add(item))
        {
            gameObject.SetActive(false);
            GameManager.instance.isHammerPickedUp = true;
        }
    }

}
