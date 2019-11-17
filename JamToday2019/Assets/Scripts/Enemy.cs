using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public  PlayerController TargetPlayer;
    public int HitPoints = 1;
    public int AttackDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(GetComponent<AIDestinationSetter>()!=null)
            GetComponent<AIDestinationSetter>().target = TargetPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(TargetPlayer.transform.position, transform.forward);
    }

    public virtual void ReceiveDamage(int damage)
    {
        HitPoints -= damage;
        if (HitPoints <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        GameController.instance.enemies.RemoveAt( GameController.instance.enemies.IndexOf(this));
        Destroy(this.gameObject);
    }
}
