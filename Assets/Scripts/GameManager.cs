using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public static List<Item> currentInventoryItems = new List<Item>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);

    }

    public static void SetCurrentInventoryItems(List<Item> items)
    {
        // Convert the item list to a array of names
        ///List<Item> items = new List<Item>();
        foreach (Item item in items)
        {
            Debug.Log(item.name + "is spawned from the saving");
            items.Add(item);
        }

        // add new items added to inventory
        foreach (Item newItem in items)
        {
            if (!currentInventoryItems.Contains(newItem))
                currentInventoryItems.Add(newItem);
        }

        // Discard items removed from inventory
        foreach (Item usedItem in currentInventoryItems.ToArray())
        {
            if (!items.Contains(usedItem))
                currentInventoryItems.Remove(usedItem);
        }
    }

    public static void AddInventoryItem(Item item)
    {
        if (!currentInventoryItems.Contains(item)) 
        {
            currentInventoryItems.Add(item);
            Debug.Log(item.name + "saved.");
        }

    }

    public static void RemoveInventoryItem(Item item)
    {
        if (currentInventoryItems.Contains(item))
            currentInventoryItems.Remove(item);
    }

}

   
