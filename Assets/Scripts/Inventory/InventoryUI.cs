using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    InventoryManager inventory;
    public Image icon;
    Item item;

    //public bool isInventoryFull;
    
    void Awake()
    {
        if(!item)
        {
            icon.enabled = false;
        }
     
    }

    void Start()
    {
        inventory = InventoryManager.instance;
        if(inventory != null)
          inventory.onItemChangedCallback += UpdateUI;

        Debug.Log("hammer pick up:" + GameManager.instance.isHammerPickedUp);
        //isIventoryFull = GameManager.instance.isHammerPickedUp;

        
    }

    void Update()
    {
        if (!GameManager.instance.isHammerPickedUp)
        {
            GameManager.instance.isInventoryFull = false;
        }
        else
        {
            GameManager.instance.isInventoryFull = true;
        }
    }

    public void UpdateUI()
    {
        for (int i=0; i<inventory.items.Count; i++)
        {
            AddItem(inventory.items[i]);
            GameManager.instance.isInventoryFull = true;
            Debug.Log("isInventoryFull set true from InventoryUI UpdateUI");
        }

    }

    public void AddItem(Item newItem)
    {
        if (!GameManager.instance.isInventoryFull)
        {
            item = newItem;
            //print(item);
            icon.sprite = item.icon;
            icon.enabled = true;
        }
       
    }

    public void ClearItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    private void OnDestroy()
    {
        Debug.Log("UI was destroyed");
    }
}
