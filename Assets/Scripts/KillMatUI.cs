using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillMatUI : MonoBehaviour
{
    public GameObject killMatUI;
   // public Item item;
    public ItemPickup item;
    private void Start()
    {
        killMatUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")// && item.isHammer)
        {
            killMatUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")// && item.isHammer)
        {
            killMatUI.SetActive(false);
        }
    }
}
