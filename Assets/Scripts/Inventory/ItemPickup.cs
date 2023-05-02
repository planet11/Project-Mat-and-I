using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //public bool inUI;
    public bool isPickedUp = false;

    public Item item;
    //public static Item Instance; //Item's static instance


    //private void Start()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
        
    //}
    void OnMouseDown()
    {

        //if (Inventory.instance.Add(Instance))
        if (Inventory.instance.Add(item))
        {
            isPickedUp = true;
            Destroy(gameObject);
            
            //gameObject.GetComponent<Item>().inUI = true;
            //Destroy(Instance);
        }
    }

}
