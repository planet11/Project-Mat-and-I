using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public Image icon;
    Item item;
    
    void Awake()
    {
        if(!item)
        {
            icon.enabled = false;
        }
     
    }

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i=0; i<inventory.items.Count; i++)
        {
            AddItem(inventory.items[i]);
        }

    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        print(item);
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
