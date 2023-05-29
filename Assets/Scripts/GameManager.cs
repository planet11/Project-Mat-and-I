using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public bool isHammerPickedUp;
    public bool isInventoryFull;

    public string sceneToLoad; 

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

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeScene();
        }
    }


}
