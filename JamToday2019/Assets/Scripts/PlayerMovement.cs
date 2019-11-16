using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Move(float horizontalAxis, float verticalAxis)
    {
        Vector2 Movement = new Vector2(horizontalAxis, verticalAxis);
        rb.MovePosition(rb.position + Movement * speed * Time.deltaTime);

    }

    internal void Rotate(Vector2 camPos)
    {
        Vector2 lookDir = camPos - rb.position;
        float angle = Mathf.Atan2(camPos.y, camPos.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
}
