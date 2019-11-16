using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private float HorizontalAxis;
    private float VerticalAxis;
    private PlayerMovement playerMovement;
    public Camera cam;
    public GameObject projectile;
    public GameObject FirePoint;

    Vector2 camPos;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalAxis = Input.GetAxisRaw("Horizontal");
        VerticalAxis = Input.GetAxisRaw("Vertical");
        //print($"Horizontal= {HorizontalAxis}, vertical = {VerticalAxis}");
        camPos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

    }

    private void Fire()
    {
        Instantiate(projectile, FirePoint.transform.position, FirePoint.transform.rotation);
    }

    private void FixedUpdate()
    {
        playerMovement.Move(HorizontalAxis, VerticalAxis);
        playerMovement.Rotate(camPos);

    }
}
