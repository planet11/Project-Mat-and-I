using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public void Awake()
    {
        Instance = this;
    }

    public enum Scene //store the scenes in order, check build settings for order
    {
        Start,Bedroom, Controlroom, Corridor
    }

    public void LoadScene(Scene scene) //loads the scene
    {
        SceneManager.LoadScene(scene.ToString());//converts scene index to string
    }

    public void LoadNewGame()//to load the first level form the main menu
    {
        SceneManager.LoadScene(Scene.Bedroom.ToString());
    }

    public void LoadNextScene()//to load the next scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()//to load the start menu
    {
        SceneManager.LoadScene(Scene.Start.ToString());
    }
}
