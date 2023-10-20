using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class EnemyScript : MonoBehaviour
{
    public float initialVelocity;
    public static float difMod; // Modifier that changes how likely the enemy is to hit; Based on menu choice (Difficulty Modifier)
    [Range(0, 10)] public static float iterMod; // Modifier that alters how likely the enemy is to hit; Decreases per shot (Iterating Modifier)
    public static float fireMod;
    [Range(-90, 0)] public float launchAngle = 0;
    public static float fireRate;
    [SerializeField] private float nextFire;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float currentTime;
    

    public GameObject firepoint;
    public GameObject gameGen;

    public AudioSource artilleryShotAudio;

    Quaternion currentRot;

    void Awake()
    {
        nextFire = Time.fixedTime + fireRate - UnityEngine.Random.Range(0, fireMod);
    }

    void Update()
    {
        currentRot.eulerAngles = new Vector3(0, 0, launchAngle);
        transform.rotation = currentRot;
        currentTime = Time.fixedTime;
        if(Time.time > nextFire)
        {
            nextFire = Time.fixedTime + fireRate - UnityEngine.Random.Range(0, fireMod);
            Shoot();
        }
        
    }

    public void Shoot()
    {
        artilleryShotAudio.Play();
        launchAngle = UnityEngine.Random.Range(-60f, -30f);
        float radAngle = launchAngle * Mathf.Deg2Rad;
        GameObject projectileClone = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);

        float distance = gameGen.GetComponent<LoadLevel>().distanceInMeters;

        initialVelocity = (float)Math.Sqrt(Math.Abs((9.81 * (double)distance) / Math.Sin(2 * (double)radAngle)));
        initialVelocity /= 10.15f;
        initialVelocity += UnityEngine.Random.Range((-iterMod - difMod), iterMod + difMod); 

        float xSpeed = 0.0f;
        float ySpeed = 0.0f;

       

        xSpeed = (float)(initialVelocity * Math.Cos((double)radAngle));
        ySpeed = (float)(initialVelocity * Math.Sin((double)radAngle));

        Vector2 fireDir = new Vector2(-xSpeed, -ySpeed);
        Rigidbody2D proj = projectileClone.GetComponent<Rigidbody2D>();
        proj.AddForce(fireDir, ForceMode2D.Impulse);
        if(iterMod > 1f)
        {
            iterMod -= UnityEngine.Random.Range(0.5f, 1f);
        }
        
    }
}
