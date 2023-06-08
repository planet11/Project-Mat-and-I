using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string sceneToLoad; //to check which scene to load
    GameManager gameManager;
    private static GameObject destroyedItemInScene;

    private void Start()
    {
        gameManager = GameManager.instance;
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
