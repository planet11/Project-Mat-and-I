using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    InventoryManager inventory;
    public Image icon;
    Item item;

    [SerializeField] private AudioSource collectSound; // collect audio
    bool isInventoryFull = false;

    void Awake()
    {
        if (!item)
            icon.enabled = false;
    }

    void Start()
    {
        //bool isInventoryFull = false;
        
        inventory = InventoryManager.instance;
        if (inventory != null)
        {
            inventory.itemChanged += UpdateUI;
            collectSound.Pause();
        }
            
    }

    void OnDisable()
    {
        InventoryManager.instance.itemChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < inventory.items.Count; i++)
            if (i < inventory.items.Count)
            {
                AddItem(inventory.items[i]);
                //collectSound.Play();//audio 
            }
                  
            else
                ClearItem();
    }

    public void AddItem(Item newItem)
    {
        if(inventory == null)
        {
            item = newItem;
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
}
