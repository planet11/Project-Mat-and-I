using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    InventoryManager inventory;
    public Item item;
    bool isCollectable = false;

    [SerializeField] private AudioSource collectSound; // collect audio

    private void Start()
    {
        inventory = InventoryManager.instance;
        collectSound.Pause();
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
            collectSound.Play(); // play audio

            inventory.Add(item);
            Destroy(gameObject);
            
            Debug.Log("Collect sound played!!");
        }
    }

}
