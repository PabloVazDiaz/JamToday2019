﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Health : MonoBehaviour
{
    [SerializeField]
    float maxHitPoints = 1f;
    float hitPoints;

    [SerializeField]
    float weight = 1;

    
    public event Action onDie;

    void Awake()
    {
        hitPoints = maxHitPoints;
        
    }

    
    public void TakeDamage(GameObject instigator, float damage)
    {
        hitPoints = Mathf.Max(hitPoints - damage, 0);
        //Sound effect?

        Knockback(instigator);
        if (hitPoints <= 0)
            Die();
    }

    private void Knockback( GameObject instigator)
    {
        float hitforce = instigator.GetComponent<Projectile>().force * 1000;
        GetComponent<Rigidbody2D>().AddForce((transform.position - instigator.transform.position) * hitforce / weight);
    }

    private void Die()
    {
        onDie?.Invoke();
        Destroy(gameObject);
    }
}
