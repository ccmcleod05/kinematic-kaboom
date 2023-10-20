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

    public GameObject highEasyScoreDisplayTextField;
    public GameObject highMediumScoreDisplayTextField;
    public GameObject highHardScoreDisplayTextField;

    private int highScoreDisplay;
    public static String difficulty;

    public void Start(){
        highScoreDisplay = PlayerPrefs.GetInt("EasyHighScore");
        highScoreDisplay = PlayerPrefs.GetInt("IntermediateHighScore");
        highScoreDisplay = PlayerPrefs.GetInt("HardHighScore");
        PlayerPrefs.SetInt("CurrentScore", 0);

        highEasyScoreDisplayTextField.GetComponent<Text>().text = Convert.ToString(PlayerPrefs.GetInt("EasyHighScore"));
        highMediumScoreDisplayTextField.GetComponent<Text>().text = Convert.ToString(PlayerPrefs.GetInt("IntermediateHighScore"));
        highHardScoreDisplayTextField.GetComponent<Text>().text = Convert.ToString(PlayerPrefs.GetInt("HardHighScore"));
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
        difficulty = "easy";
        EnemyScript.difMod = 10f;
        EnemyScript.iterMod = 10f;
        EnemyScript.fireMod = 10f;
        EnemyScript.fireRate = 60f;
        float integer = UnityEngine.Random.Range(0, 2);
        if(integer == 0){
            SceneManager.LoadScene("Pacific");
        }
        else if(integer == 1){
            SceneManager.LoadScene("Meditteranean");
        }
        else{
            SceneManager.LoadScene("Arctic");
        }
    }

    public void Medium(){
        // Change computer script probability instance variable
        difficulty = "med";
        EnemyScript.difMod = 5f;
        EnemyScript.iterMod = 5f;
        EnemyScript.fireMod = 15f;
        EnemyScript.fireRate = 45f;
        float integer = UnityEngine.Random.Range(0, 2);
        if(integer == 0){
            SceneManager.LoadScene("Pacific");
        }
        else if(integer == 1){
            SceneManager.LoadScene("Meditteranean");
        }
        else{
            SceneManager.LoadScene("Arctic");
        }
    }

    public void Hard(){
        // Change computer script probability instance variable
        difficulty = "hard";
        EnemyScript.difMod = 0f;
        EnemyScript.iterMod = 1.5f;
        EnemyScript.fireMod = 15f;
        EnemyScript.fireRate = 25f;
        float integer = UnityEngine.Random.Range(0, 2);
        if(integer == 0){
            SceneManager.LoadScene("Pacific");
        }
        else if(integer == 1){
            SceneManager.LoadScene("Meditteranean");
        }
        else{
            SceneManager.LoadScene("Arctic");
        }
    }

    // Quit the application.
    public void Quit(){
        Application.Quit();
    }
}
