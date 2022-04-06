﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;

    public void UpdateScore(int score)
    {
        Debug.Log("UIManager.UpdateScore(): _textManager.text: " + _scoreText.text + " score: " + score);
        _scoreText.text = Constants.STRING_SCORE + score;
    }

    public void DisplayGameOverText()
    {
        _gameOverText.text = Constants.STRING_GAME_OVER;
    }
}
