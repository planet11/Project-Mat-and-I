using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string sceneToLoad; //to check which scene to load
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ChangeScene(sceneToLoad);
        }
    }
}
