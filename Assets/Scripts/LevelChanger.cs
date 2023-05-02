using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string sceneToLoad; //to check which scene to load

    public static LevelChanger Instance;
    void Start()
    {
        //if (Instance != null)
        //{
        //    Destroy(this.gameObject);
        //    return;
        //}
    //    Instance = this;
    //    GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeScene();
        }
    }
}
