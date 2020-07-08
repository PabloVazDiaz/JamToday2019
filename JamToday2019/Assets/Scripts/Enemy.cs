using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    PlayerController TargetPlayer;
    public Sprite damagedSprite;

    // Start is called before the first frame update
    void Start()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(GetComponent<AIDestinationSetter>()!=null)
            GetComponent<AIDestinationSetter>().target = TargetPlayer.transform;
        GetComponent<Fighter>().target = TargetPlayer.gameObject.GetComponent<Health>();
    }

 

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(TargetPlayer.transform.position, transform.forward);
       //Check distance and attack if possible

    }
    /*
    public virtual void ReceiveDamage(int damage)
    {
        if (damagedSprite != null)
        {
            StartCoroutine(DamageAnimation());
        }
        if (isInvencible)
            return;
        HitPoints -= damage;
        if (Boss)
            BossHealth.fillAmount = HitPoints / InitialHitPoints;
        
        if(Boss && HitPoints % 10 == 0)
        {
            //isInvencible = true;
            SummonEnemies();
        }
        
        if (HitPoints <= 0)
        {
            if (Child != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject go = Instantiate(Child, transform.position, transform.rotation);
                    go.transform.parent = null;
                }
            }
            Die();
        }
    }

    private IEnumerator DamageAnimation()
    {
        originalSprite = GetComponentInChildren<SpriteRenderer>().sprite;
        GetComponentInChildren<SpriteRenderer>().sprite = damagedSprite;
        yield return new WaitForSeconds(0.5f);
        GetComponentInChildren<SpriteRenderer>().sprite = originalSprite;
    }
    public Enemy[] enemiesToSpawn;
    public GameObject[] SpawnPoints;
    
    private void SummonEnemies()
    {
        //throw new NotImplementedException();
        foreach (Enemy enemy in enemiesToSpawn)
        {
            Instantiate(enemy.gameObject, SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count())].transform);
        }
    }

    public virtual void Die()
    {
        GameController.instance.enemies.Remove( (this.gameObject));
        Destroy(this.gameObject);
        if (Boss)
        {
            GameController.instance.Victory();
        }
    }
    */
}
