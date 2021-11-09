using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class PlayerInGameInterface : MonoBehaviour
{
    public GameObject currentScoreDisplayTextField;
    public GameObject highScoreDisplayTextField;
    public GameObject distanceDisplayTextField;

    public GameObject initialVelocityInputText;
    public GameObject angleInputText;

    public GameObject enterButton;

    public GameObject initialVelocityInputField;
    public GameObject angleInputField;

    public GameObject gameGenerator;

    public GameObject playerBattleship;

    void Start()
    {
        playerBattleship = gameGenerator.GetComponent<LoadLevel>().player;
        if(PlayerPrefs.GetInt("HighScore") == PlayerPrefs.GetInt("CurrentScore")){
            PlayerPrefs.SetInt("HighScore", LoadLevel.score);
            PlayerPrefs.SetInt("CurrentScore", LoadLevel.score);
        }
        PlayerPrefs.SetInt("CurrentScore", LoadLevel.score);
        highScoreDisplayTextField.GetComponent<Text>().text = Convert.ToString(PlayerPrefs.GetInt("HighScore"));
        currentScoreDisplayTextField.GetComponent<Text>().text = Convert.ToString(PlayerPrefs.GetInt("CurrentScore"));
        DisplayDistance();
    }

    public void EnterInput(){
        AssignInputs();
        initialVelocityInputText.GetComponent<InputField>().text = "";
        angleInputText.GetComponent<InputField>().text = "";
    }

    public void Disable(){
        enterButton.GetComponent<Button>().interactable = false;
        initialVelocityInputText.GetComponent<InputField>().interactable = false;
        angleInputText.GetComponent<InputField>().interactable = false;
    }

    public void Enable(){ // When shipmissed and cooldown over
        enterButton.GetComponent<Button>().interactable = true;
        initialVelocityInputText.GetComponent<InputField>().interactable = true;
        angleInputText.GetComponent<InputField>().interactable = true;
    }

    public void DisplayDistance(){
        distanceDisplayTextField.GetComponent<Text>().text = Convert.ToString(gameGenerator.GetComponent<LoadLevel>().distanceInMeters) + " M";
    }

    public void AssignInputs(){
        if(initialVelocityInputField.GetComponent<Text>().text != null || angleInputField.GetComponent<Text>().text != null){
            if(float.TryParse(initialVelocityInputField.GetComponent<Text>().text, out float n)){ // Check if init vel user input is numeric
                if(float.Parse(initialVelocityInputField.GetComponent<Text>().text) < 131 && float.Parse(initialVelocityInputField.GetComponent<Text>().text) > 0){
                    float initVel = float.Parse(initialVelocityInputField.GetComponent<Text>().text);
                    playerBattleship.GetComponent<ShootingScript>().initialVelocity = initVel;

                    if(float.TryParse(angleInputField.GetComponent<Text>().text, out float i)){ // Check if angle user input is numeric
                        if(float.Parse(angleInputField.GetComponent<Text>().text) < 91 && float.Parse(angleInputField.GetComponent<Text>().text) > -1){ // Check if angle is positive and complementary
                            float angle = float.Parse(angleInputField.GetComponent<Text>().text);
                            playerBattleship.GetComponent<ShootingScript>().launchAngle = angle;

                            playerBattleship.GetComponent<ShootingScript>().Shoot();
                            Disable();
                            //Task.Delay(new TimeSpan(0, 0, 5)).ContinueWith(o => { Enable(); });
                        }
                    }
                }
            }
        }
    }
}
