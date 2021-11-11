using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.Audio;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject difficultyMenu;
    public GameObject optionsMenu;
    public AudioMixer audioMixer;

    private int highScoreDisplay;

    public void Start(){
        highScoreDisplay = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    public void Play(){
        difficultyMenu.SetActive(true);
    }

    public void Settings(){
        optionsMenu.SetActive(true);
    }



    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            DisableMenu();
        }
    }

    void DisableMenu(){
        optionsMenu.SetActive(false);
        difficultyMenu.SetActive(false);
    }




    void EnableOptionsMenu(){
        optionsMenu.SetActive(true);
    }


    void EnableDifficultyMenu(){
        difficultyMenu.SetActive(true);
    }



    public void SetVolume(float volume){
        audioMixer.SetFloat("Volume", volume);
        SaveVolume(volume);
    }

    public void SaveVolume(float volume){
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void LoadVolume(){
        float volume = PlayerPrefs.GetFloat("Volume");
        SetVolume(volume);
    }



    // Plays the game with the chosen difficulty.
    public void Easy(){
        // Change computer script probability instance variable
        float integer = UnityEngine.Random.Range(0, 2);
        if(integer == 0){
            SceneManager.LoadScene("Pacific");
        }
        else if(integer == 1){
            SceneManager.LoadScene("Pacific");
        }
        else{
            SceneManager.LoadScene("Pacific");
        }
    }

    public void Medium(){
        // Change computer script probability instance variable
        float integer = UnityEngine.Random.Range(0, 2);
        if(integer == 0){
            SceneManager.LoadScene("Pacific");
        }
        else if(integer == 1){
            SceneManager.LoadScene("Pacific");
        }
        else{
            SceneManager.LoadScene("Pacific");
        }
    }

    public void Hard(){
        // Change computer script probability instance variable
        float integer = UnityEngine.Random.Range(0, 2);
        if(integer == 0){
            SceneManager.LoadScene("Pacific");
        }
        else if(integer == 1){
            SceneManager.LoadScene("Pacific");
        }
        else{
            SceneManager.LoadScene("Pacific");
        }
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
