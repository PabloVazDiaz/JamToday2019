using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //public PlayerController initialPlayer = new PlayerController { speed = 2f, health = 1 };

    bool isInvulnerable;
    Rigidbody2D rb;
    public float speed;
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        //GameController.instance.UpdateLifeCanvas();
        rb = GetComponent<Rigidbody2D>();
        if (PlayerController.instance == null)
        {
            PlayerController.instance = this;
        }
        else
        {
            Destroy(this);
        }
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
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }

    public void GetDamaged( int damage)
    {
        if (isInvulnerable)
            return;
        health -= damage;
        GameController.instance.UpdateLifeCanvas();
        BeInvulnerable();
        if (health <= 0)
        {
            Destroy(this.gameObject);
            //GameController.instance.GameOver();
        }
    }

    private void BeInvulnerable()
    {
        isInvulnerable = true;
        //animation
        StartCoroutine(BlinkSprite());
        //disableCollider

        //throw new NotImplementedException();
    }

    private IEnumerator BlinkSprite()
    {
        SpriteRenderer sprite=GetComponentInChildren<SpriteRenderer>();
        for (int i = 0; i < 6; i++)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.25f);
        }
        isInvulnerable = false;
    }
}
