using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    InventoryManager inventory;
    GameManager gameManager;
    public Item item;
    bool isCollectable = false;

    private void Start()
    {
        inventory = InventoryManager.instance;
        gameManager = GameManager.instance;
        if (gameObject.name == gameManager.destroyedItem)
            gameObject.SetActive(false);
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
        if (isCollectable && inventory.items.Count < inventory.space)
        {
            inventory.Add(item);
            gameManager.DestroyedItem(gameObject.name);
            gameObject.SetActive(false);
            InventoryUI.instance.UpdateUI();
            Debug.Log("UI Updated");
        }
    }

}
