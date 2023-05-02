using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    Inventory inventory;
    public Image icon;
    Item item;
    
    void Awake()
    {
        //if(!item && gameObject.GetComponent<Item>().inUI == false)
        if (!item)
        {
            icon.enabled = false;
        }
        //else if (gameObject.GetComponent<ItemPickup>().isPickedUp == true)
        //{
        //    icon.enabled = true;
        //    Debug.Log("this is run");
        //}

    }

    void Start()
    {
        //while (gameObject.GetComponent<ItemPickup>().isPickedUp != true)
        //{
        //    inventory = Inventory.instance;
        //    inventory.onItemChangedCallback += UpdateUI;
        //}
        
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
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
