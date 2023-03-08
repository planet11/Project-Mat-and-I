using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemBtn;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
    }

    //check if the player collides with the item
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++) //check if there are any inventory slots empty
            {
                if (inventory.isFull[i] == false)
                {
                    //add item to inventory
                    inventory.isFull[i] = true;
                    Instantiate(itemBtn, inventory.slots[i].transform, false); //puts the object into the first available empty slot
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
