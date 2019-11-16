using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public  PlayerController TargetPlayer;
    int HitPoints = 1;
    public int AttackDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        GetComponent<AIDestinationSetter>().target = TargetPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(TargetPlayer.transform.position, transform.forward);
    }

    public void ReceiveDamage(int damage)
    {
        HitPoints -= damage;
        if (HitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
