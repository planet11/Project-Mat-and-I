using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillMatUI : MonoBehaviour
{
    public GameObject killMatUI;
    //public ItemPickup item;
 
  
    private void Start()
    {
        killMatUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && InventoryManager.instance.hasHammer)
        {
            killMatUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            killMatUI.SetActive(false);
        }
    }
}
