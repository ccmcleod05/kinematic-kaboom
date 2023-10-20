using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class InGameMenu : MonoBehaviour{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;

    /* --- Volume --- */

    public void SetVolume(float Volume){
        /*if(PlayerPrefs.GetFloat("Volume") != null){
            LoadVolume();
        }*/
        audioMixer.SetFloat("Volume", Volume);
        SaveVolume(Volume);
    }

    public void SaveVolume(float Volume){
        PlayerPrefs.SetFloat("Volume", Volume);
    }

    public void LoadVolume(){
        float Volume = PlayerPrefs.GetFloat("Volume");
        SetVolume(Volume);
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

