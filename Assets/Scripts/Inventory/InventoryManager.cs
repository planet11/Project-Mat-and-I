using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    /*public bool[] isFull;
    public GameObject[] slots;*/

    public static InventoryManager instance { get; private set; }
    public List<Item> items = new List<Item>();

    //public GameObject hammer;
    //public bool isHammerPickedUp;

    InventoryUI ui;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        
    }
    #endregion
   
    

    public int space = 1;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public bool Add(Item item)
    {
        //if (!item.isDefaultItem)
        //{
            if(items.Count >= space)
            {
                Debug.Log("FULL");
                return false; 
            }

            items.Add(item);
            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        //}
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
