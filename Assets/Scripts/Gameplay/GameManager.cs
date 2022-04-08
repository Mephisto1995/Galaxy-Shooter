using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver)
        {
            RestartGameSequence();
        }
    }

    public void SetGameOver(bool status)
    {
        _isGameOver = status;
    }

    private void RestartGameSequence()
    {
        SceneManager.LoadScene(Constants.SCENE_GAME);
        SetGameOver(false);
    }
}
