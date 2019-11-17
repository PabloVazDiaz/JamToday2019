﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float timeLastShoot = 0;
    private bool isAbleToFire = true;
    private float HorizontalAxis;
    private float VerticalAxis;
    private PlayerController playerMovement;
    public Transform FirePoint;
    public Camera cam;
    public Projectile projectile;
    

    Vector2 camPos;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalAxis = Input.GetAxisRaw("Horizontal");
        VerticalAxis = Input.GetAxisRaw("Vertical");
        //print($"Horizontal= {HorizontalAxis}, vertical = {VerticalAxis}");
        camPos = cam.ScreenToWorldPoint(Input.mousePosition);
        timeLastShoot += Time.deltaTime;
        isAbleToFire = (timeLastShoot > PlayerController.instance.ShootCD);
        if (Input.GetButtonDown("Fire1") && isAbleToFire)
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameController.instance.Pause();
        }

    }

    private void Fire()
    {
        timeLastShoot = 0;
        GameObject bullet =Instantiate(projectile.gameObject, FirePoint.position, FirePoint.rotation);

        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * projectile.speed, ForceMode2D.Impulse);


    }

    private void FixedUpdate()
    {
        playerMovement.Move(HorizontalAxis, VerticalAxis);
        playerMovement.Rotate(camPos);

    }
}
