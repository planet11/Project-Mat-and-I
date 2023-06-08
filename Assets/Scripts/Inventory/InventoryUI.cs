using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    InventoryManager inventory;
    public static InventoryUI instance;
    public Image icon;
    Item item;
    public bool isItemInUI = false;
    
    
    void Awake()
    {
        if(!item)
            icon.enabled = false;

        instance = this;
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
            if (inventory.items.Count != 0)
            {
                //print(item);
                Debug.Log("item is added");
                AddItem(inventory.items[i]);
                isItemInUI = true;

            }
            else
            {
                ClearItem();
            }
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

}
