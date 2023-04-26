using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button _startGame;

    // Update is called once per frame
    void start()
    {
        _startGame.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        LevelManager.Instance.LoadNewGame();
    }
}
