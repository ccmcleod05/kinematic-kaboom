using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
    The player class will handle everything that has to do with the player - saving the player's score, health, and connecting the Shooting and 
    Kinematics classes.
    */

    private int health = 100;
    private int highScore;
    private int currentScore;

    // Start is called before the first frame update
    void Start(){
        LoadPlayer();
    }

    // Update is called once per frame
    void Update(){
        SavePlayer();
    }

    void TakeDamage(int damage, GameObject player){
        health -= damage;
        if(health <= 0)
        {
            //Open GameOver Menu and Pause Scene
            //SceneManager.LoadScene("GameOver");
        }
    }

    // Saves highest score.
    public void SavePlayer(){
        if(currentScore > highScore)
            PlayerPrefs.SetInt("HighScore", currentScore);
    }

    // Loads high score.
    public void LoadPlayer(){
        highScore = PlayerPrefs.GetInt("HighScore");
    }
}
