using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void QuitToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
