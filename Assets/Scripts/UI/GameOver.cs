using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject highScoreDisplayTextField;

    void Update(){
        highScoreDisplayTextField.GetComponent<Text>().text = Convert.ToString(PlayerPrefs.GetInt("CurrentScore"));
    }

    public void QuitToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
