using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //public static ItemPickup instance { get; private set; }
    public static ItemPickup instance;

    InventoryManager inventory;
    GameManager gameManager;
    
    public Item item;
    public bool isCollectable = false;
    [SerializeField] private AudioSource collectSound;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventory = InventoryManager.instance;
        gameManager = GameManager.instance;
        if(gameManager.IsItemDestroyed(gameObject.name))
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
            collectSound.Play();
            inventory.Add(item);
            gameObject.SetActive(false);
            InventoryUI.instance.UpdateUI();
            Debug.Log(item);
        }
    }

}
