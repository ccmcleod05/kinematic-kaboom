using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int highScoreDisplay = PlayerPrefs.GetInt("HighScore");

    public void Start(){
        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    // Plays the game with the chosen difficulty.
    public void Easy(){
        SceneManager.LoadScene("EasyDifficulty");
    }

    public void Medium(){
        SceneManager.LoadScene("MediumDifficulty");
    }

    public void Hard(){
        SceneManager.LoadScene("HardDifficulty");
    }

    // Get the high score to display.
    public int GetHighScore(){
        return highScoreDisplay;
    }

    // Quit the application.
    public void Quit(){
        Application.Quit();
    }
}
