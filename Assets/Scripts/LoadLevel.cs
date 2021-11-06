using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class LoadLevel : MonoBehaviour
{
    /*
    When the player destroys the battleship, a new scene must be generated with a random distance between the
    player and computer battleships.
    */

    private int seed;
    private int distance;

    public GameObject playerBattleship;
    public GameObject computerBattleship;

    void Awake(){

    }

    // Start is called before the first frame update
    void Start(){
        GenerateSeed();
        CalculateDistance();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void GetSeed(){
        return seed;
    }

    void GenerateSeed(){
        Random random = new Random(seed);
        Debug.log(random.Next());
        seed = random.Next();
    }

    void CalculateDistance(){
        distance = seed; // Do math for pixel distance from seed
    }

    void SpawnBattleships(){
        // x coordinates are that distance away from each other upon instantiation

        GameObject player = Instantiate(playerBattleship, playerPos, playerBattleship.transform.rotation); // Player
        GameObject computer = Instantiate(computerBattleship, computerPos, computerBattleship.transform.rotation); // Computer
        // player.transform.rotation.z = 
        // player.transform.rotation.z = 
    }
}
