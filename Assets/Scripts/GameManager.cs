using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public bool isHammerPickedUp;
    public bool isInventoryFull;

    public static GameManager instance { get; private set; }

    //InventoryUI ui;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        isHammerPickedUp = false;
        isInventoryFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isInventoryFull)
        //{
        //    ui.UpdateUI();
        //    Debug.Log("Updateui happened from GameManager");
        //}
    }
}
