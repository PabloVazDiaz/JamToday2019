using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Enemy enemy;
    public Projectile projectile;
    public Transform FirePoint;
    public float ShootCoolDown;

    private float TimeLastShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();    
    }

    // Update is called once per frame
    void Update()
    {
        if((enemy.TargetPlayer.gameObject.transform.position - transform.position).magnitude < 12f && TimeLastShoot > ShootCoolDown)
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
        GameObject bullet = Instantiate(projectile.gameObject, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * projectile.speed, ForceMode2D.Impulse);
        bullet.GetComponent<Projectile>().damage = enemy.AttackDamage;
    }
}
