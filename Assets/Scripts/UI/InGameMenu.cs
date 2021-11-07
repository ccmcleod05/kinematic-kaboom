using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class InGameMenu : MonoBehaviour{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    

    /* --- Volume --- */

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


    /* --- Pause --- */

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }

    void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    /* --- QuitToMainMenu --- */

    public void QuitToMainMenu(){
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}

