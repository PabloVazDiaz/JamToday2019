using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public Health target;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void PrepareWeapons(Weapon[] weapons)
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.TimeLastFired = 0;
            //Ammo from shop
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackBehaviour(Weapon weapon)
    {
        if (isInRange(target, weapon) && canAttack(weapon))
        {
            if (weapon.type == WeaponType.Melee)
                Hit(weapon);
            if (weapon.type == WeaponType.Ranged)
                Shoot(weapon);
            weapon.TimeLastFired = Time.time;
        }

    }


    private bool canAttack(Weapon weapon)
    {
        bool hasAmmo = weapon.Ammo > 0 ? true : false;
        
        return Time.time - weapon.TimeLastFired > weapon.FireCoolDown && hasAmmo ;
    }


    //Animation Event
    void Hit(Weapon weapon)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(weapon.Range, weapon.Range), 0f);
        foreach (var col in colliders)
        {
            if(col.GetComponent<Health>() == target)
            {
                target.TakeDamage(gameObject, weapon.Damage, weapon.Force);
            }
        }   
        
    }

    //Animation Event
    void Shoot(Weapon weapon)
    {
        foreach (Projectile projectile in weapon.projectiles)
        {
            //GameObject bullet = Instantiate(projectile.gameObject, FirePoint.position, FirePoint.rotation);
            Vector2 FirePoint = transform.position + transform.up;
            GameObject bullet = Instantiate(projectile.gameObject, FirePoint, transform.rotation);
            bullet.transform.Rotate(bullet.transform.forward, UnityEngine.Random.Range(-bullet.GetComponent<Projectile>().apperture, bullet.GetComponent<Projectile>().apperture));
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * projectile.speed, ForceMode2D.Impulse);
            bullet.GetComponent<Projectile>().damage = weapon.Damage;
            weapon.Ammo--;
        }
    }

    private bool isInRange(Health target, Weapon weapon)
    {
        if (target == null)
            return true;
        return (target.transform.position - transform.position).magnitude < weapon.Range;
    }
}
