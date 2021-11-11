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
    public int currentScore;

    // Start is called before the first frame update
    void Start(){
        LoadPlayer();
    }

    // Update is called once per frame
    void Update(){
        SavePlayer();
    }

    public void IncrementScore()
    {
        currentScore++;
    }
    
    void TakeDamage(int damage){
        health -= damage;
        if(health <= 0)
        {
            //Open GameOver Menu and Pause Scene
            //SceneManager.LoadScene("GameOver");
        }
    }

    // Saves highest score.
    public void SavePlayer(){
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        if (currentScore >= highScore)
            PlayerPrefs.SetInt("HighScore", currentScore);
        PlayerPrefs.SetInt("CurrentScore", currentScore);
    }

    // Loads high score.
    public void LoadPlayer(){
        highScore = PlayerPrefs.GetInt("HighScore");
    }
}
