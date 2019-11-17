using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    public bool isInvencible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ReceiveDamage(int damage)
    {
        if (isInvencible)
            return;
        base.ReceiveDamage(damage);
        if (HitPoints % 10 == 0)
        {
            isInvencible = true;
            SummonEnemies();
        }
    }

    private void SummonEnemies()
    {
        //animation
        //spawn
        throw new NotImplementedException();
    }

    public override void Die()
    {
        base.Die();
        GameController.instance.Victory();
    }
}
