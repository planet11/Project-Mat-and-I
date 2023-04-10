using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    /*public bool[] isFull;
    public GameObject[] slots;*/

    public static Inventory instance;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("An instance of Inventory exists!");
            return;
        }
        instance = this;
    }
    #endregion

    public int space = 1;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;


    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("FULL");
                return false;
            }

            items.Add(item);
            if(OnItemChangedCallback != null)
            {
                OnItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
}
