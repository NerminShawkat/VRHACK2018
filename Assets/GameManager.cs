using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameItem[] _gameItems;

    int _currentGameIndex = 0;

    private void Start()
    {
        if(_gameItems.Length > 0)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        _gameItems[_currentGameIndex].StartGame();
        _gameItems[_currentGameIndex]._onFinish.AddListener(OnGmaeFinished);
    }

    

    void OnGmaeFinished()
    {
        _currentGameIndex++;
        if(_currentGameIndex < _gameItems.Length)
        {
            StartGame();
        }
    }
}
