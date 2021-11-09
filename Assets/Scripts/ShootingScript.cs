using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.Audio;

public class ShootingScript : MonoBehaviour
{
    public float initialVelocity;
    [Range(0,90)] public float launchAngle;
    [SerializeField] private GameObject bullet;

    public GameObject firepoint;

    public AudioSource artilleryShotAudio;

    Quaternion currentRot;

    void Update()
    {
        //currentRot.eulerAngles = new Vector3(0, 0, launchAngle);
        //transform.rotation = currentRot;
    }

    public void Shoot()
    {
        artilleryShotAudio.Play();

        GameObject projectileClone = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);

        initialVelocity = initialVelocity / 10;

        float xSpeed = 0.0f;
        float ySpeed = 0.0f;

        float radAngle = launchAngle * Mathf.Deg2Rad;
        
        xSpeed = (float)(initialVelocity * Math.Cos((double)radAngle));
        ySpeed = (float)(initialVelocity * Math.Sin((double)radAngle));

        Debug.Log(xSpeed * 100);
        Debug.Log(ySpeed * 100);

        Vector2 fireDir = new Vector2(xSpeed, ySpeed);
        Rigidbody2D proj = projectileClone.GetComponent<Rigidbody2D>();
        proj.AddForce(fireDir, ForceMode2D.Impulse);

    }
}
