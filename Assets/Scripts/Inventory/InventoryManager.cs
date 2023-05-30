using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    #endregion
    
    // limit space of inventory
    public List<Item> items = new List<Item>();
    public int space = 1;

    // create event when inventory item changes
    public delegate void OnItemChanged();
    public OnItemChanged itemChanged;

    private void Start()
    {
        LoadState();
    }

    public void Add(Item item)
    {
        if(items.Count > space)
        {
            Debug.Log("Inventory is FULL");
            return; 
        }

        items.Add(item);
        itemChanged?.Invoke();
        SaveState(item);
        Debug.Log(item.name + " added to inventory");

    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (itemChanged != null)
        {
            itemChanged.Invoke();
            SaveState(item, false);
        }
    }

    void SaveState(Item item, bool isAdded = true)
    {
        if (isAdded)
            GameManager.AddInventoryItem(item);
        else
            GameManager.RemoveInventoryItem(item);
    }

    public void LoadState()
    {
        List<Item> heldItems = new List<Item>(GameManager.currentInventoryItems);
        items.Clear();

        foreach (Item heldItem in heldItems.ToArray())
            Add(heldItem);
            ///Add(Resources.Load<Item>($"Inventory Items/{name}"));
    }
}
