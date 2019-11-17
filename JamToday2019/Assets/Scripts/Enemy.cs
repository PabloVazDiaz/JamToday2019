using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public  PlayerController TargetPlayer;
    public float InitialHitPoints = 1;
    
    public float HitPoints = 1;
    public int AttackDamage = 1;
    public bool Boss;
    public Image BossHealth;
    private bool isInvencible=false;

    // Start is called before the first frame update
    void Start()
    {
        HitPoints = InitialHitPoints;
        if (Boss)
            BossHealth.gameObject.SetActive(true);
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
        if (isInvencible)
            return;
        HitPoints -= damage;
        if (Boss)
            BossHealth.fillAmount = HitPoints / InitialHitPoints;
        if(Boss && HitPoints % 10 == 0)
        {
            isInvencible = true;
            SummonEnemies();
        }
        if (HitPoints <= 0)
        {
            Die();
        }
    }

    private void SummonEnemies()
    {
        //throw new NotImplementedException();
    }

    public virtual void Die()
    {
        GameController.instance.enemies.Remove( (this.gameObject));
        Destroy(this.gameObject);
    }
}
