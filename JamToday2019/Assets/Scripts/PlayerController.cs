﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //public PlayerController initialPlayer = new PlayerController { speed = 2f, health = 1 };

    bool isInvulnerable;
    Rigidbody2D rb;
    public float speed = 3;
    public int health = 1;
    public float ShootCD=2;
    public int ShootCDBuys = 1;
    public List<Weapon> AvailableWeapons;
    public Dictionary<Weapon, int> WeaponsAmmo;
    private Weapon CurrentWeapon;
    private Fighter fighter;
    // Start is called before the first frame update
    void Start()
    {
        fighter = GetComponent<Fighter>();
        CurrentWeapon = AvailableWeapons[0];
        fighter.PrepareWeapons(AvailableWeapons.ToArray());
        //TODO Better
        WeaponsAmmo = new Dictionary<Weapon, int>();
        foreach (Weapon weapon in AvailableWeapons)
        {
            WeaponsAmmo.Add(weapon, 10);
        }



        rb = GetComponent<Rigidbody2D>();
        if (PlayerController.instance == null)
        {
            PlayerController.instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        PlayerController.instance.health= health;
        PlayerController.instance.speed = speed;
        PlayerController.instance.ShootCD = ShootCD;
        PlayerController.instance.ShootCDBuys = ShootCDBuys;
        GameController.instance.UpdateLifeCanvas();
        GameController.instance.UpdateSpeedCanvas();
        GameController.instance.UpdateCDCanvas();
    }
    void ResetPlayer()
    {
        PlayerController.instance.health = 1;
        PlayerController.instance.speed = 2;
        PlayerController.instance.ShootCD = ShootCD;
        PlayerController.instance.ShootCDBuys = 1;
        GameController.instance.UpdateLifeCanvas();
        GameController.instance.UpdateSpeedCanvas();
        GameController.instance.UpdateCDCanvas();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Move(float horizontalAxis, float verticalAxis)
    {
        Vector2 Movement = new Vector2(horizontalAxis, verticalAxis);
        if(Movement == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.MovePosition(rb.position + Movement * PlayerController.instance.speed * Time.deltaTime);

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
        PlayerController.instance.health -= damage;
        GameController.instance.UpdateLifeCanvas();
        BeInvulnerable();
        if (PlayerController.instance.health <= 0)
        {
            Destroy(this.gameObject);
            GameController.instance.GameOver();
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

    public void Fire()
    {
        if (WeaponsAmmo[CurrentWeapon] > 0)
        {
            fighter.AttackBehaviour(CurrentWeapon);
            WeaponsAmmo[CurrentWeapon]--;
        }
    }

    public void NextWeapon()
    {
        CurrentWeapon = AvailableWeapons.ElementAtOrDefault(AvailableWeapons.IndexOf(CurrentWeapon) + 1);
        if (CurrentWeapon == null)
            CurrentWeapon = AvailableWeapons[0];
    }
    public void PreviousWeapon()
    {
        CurrentWeapon = AvailableWeapons.ElementAtOrDefault(AvailableWeapons.IndexOf(CurrentWeapon) - 1);
        if (CurrentWeapon == null)
            CurrentWeapon = AvailableWeapons[AvailableWeapons.Count];
    }
}
