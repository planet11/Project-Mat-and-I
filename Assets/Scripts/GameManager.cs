using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    public bool isHammerPickedUp;
    public bool isInventoryFull;
    public Sprite inventoryIcon;
    //LevelChanger lvl = new LevelChanger;


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
        inventoryIcon = null;

    }
    private void Update()
    {
        if (inventoryIcon == null)
            Debug.Log("its null");

        else
            Debug.Log("its not null");


    }

}

   
