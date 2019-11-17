using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum Target
{
    Player,
    Enemy
}

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public Target target;
    public int damage;
    public float speed;
    public float reuse;
    public float explosionArea = 40f;
    public float apperture = 0;
    public float Delay = 0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    void Start()
    {
        StartCoroutine(ColliderDelay());
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Destroy(this.gameObject, 3f);

    }

    IEnumerator ColliderDelay()
    {
        yield return new WaitForSeconds(Delay);
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(target== Target.Enemy)
        {
            if (collision.tag == "Enemy")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy?.ReceiveDamage(damage);
            }
        }
        if(target == Target.Player)
        {
            if (collision.tag == "Player")
            {
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                player?.GetDamaged(damage);
            }
            if (collision.tag == "Shield")
            {
                return;
            }if (collision.tag == "Untagged")
            {
                return;
            }
        }

        if (collision.tag == "AttackZone")
        {
            return;
        }
        Destroy(this.gameObject);

        /*AOE
        List<Collider2D> enemies = new List<Collider2D>();
        enemies.AddRange(Physics2D.OverlapCircleAll(transform.position, explosionArea));
        if (enemies.Where(x=>x.tag=="Enemy").ToList().Count>0)
        {
            foreach (Collider2D collider in enemies.Where(x => x.tag == "Enemy").ToList())
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy?.ReceiveDamage(damage);
            }
            Destroy(this.gameObject);
        }
        */

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
