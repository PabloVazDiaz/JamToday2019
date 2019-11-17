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
    public Sprite damagedSprite;
    public float HitPoints = 1;
    public int AttackDamage = 1;
    public bool Boss;
    public Image BossHealth;
    private bool isInvencible=false;
    public GameObject Child;
    Sprite originalSprite;

    // Start is called before the first frame update
    void Start()
    {
        originalSprite = GetComponentInChildren<SpriteRenderer>().sprite;
        HitPoints = InitialHitPoints;
        if (Boss)
        {
            BossHealth = GameController.instance.HealthBoss.GetComponent<Image>();
            BossHealth.gameObject.SetActive(true);
            HitPoints += GameController.instance.plastic / 100;
            Shooting[] shooters = GetComponentsInChildren<Shooting>();
            foreach (Shooting shooter in shooters)
            {
                shooter.ShootCoolDown -= Mathf.Clamp01(GameController.instance.plastic * 0.01f);
            }
        }
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
    }
}
