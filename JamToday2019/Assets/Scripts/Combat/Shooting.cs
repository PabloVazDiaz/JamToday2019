using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Enemy enemy;
    public Projectile[] projectiles;
    public Transform FirePoint;
    public float ShootCoolDown;
    int attackDamage;
    private float TimeLastShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();    
    }

    // Update is called once per frame
    void Update()
    {
        //(enemy.TargetPlayer.gameObject.transform.position - transform.position).magnitude < 12f &&
        if ( TimeLastShoot > ShootCoolDown)
        {
            Shoot();
        }
        else
        {
            TimeLastShoot += Time.deltaTime;
        }

    }

    private void Shoot()
    {
        TimeLastShoot = 0;
        foreach (Projectile projectile in projectiles)
        {
            GameObject bullet = Instantiate(projectile.gameObject, FirePoint.position, FirePoint.rotation);
            bullet.transform.Rotate(bullet.transform.forward, UnityEngine.Random.Range(-bullet.GetComponent<Projectile>().apperture, bullet.GetComponent<Projectile>().apperture));
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * projectile.speed, ForceMode2D.Impulse);
            bullet.GetComponent<Projectile>().damage = attackDamage;
        }

    }
}
