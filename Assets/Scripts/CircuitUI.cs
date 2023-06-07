using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircuitUI : MonoBehaviour
{
    public GameObject circuitUI;
    ItemPickup item;
    public InventoryUI ui;
    private void Start()
    {
        circuitUI.SetActive(false);
        //item = FindObjectOfType<InventoryUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")// && gameObject.name=="Hammer")//&& item.name == "Hammer")
        {
            circuitUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            circuitUI.SetActive(false);
        }
    }
}
