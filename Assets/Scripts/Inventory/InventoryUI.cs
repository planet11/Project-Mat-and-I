using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    InventoryManager inventory;
    public Image icon;
    Item item;
    
    void Awake()
    {
        if(!item)
            icon.enabled = false;
    }

    void Start()
    {
        inventory = InventoryManager.instance;
        if(inventory != null)
          inventory.itemChanged += UpdateUI;
    }

    void OnDisable()
    {
        InventoryManager.instance.itemChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < inventory.items.Count; i++)
            if (i < inventory.items.Count)
                AddItem(inventory.items[i]);
            else
                ClearItem();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

 /*   public void AddItemPersist(Item newItem)
    {
        if (!GameManager.instance.isInventoryFull && GameManager.instance.inventoryIcon == null)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
        }

    }*/
}
