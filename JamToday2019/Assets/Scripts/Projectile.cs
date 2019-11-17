using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    public int damage;
    public float speed;
    public float reuse;
    public float explosionArea = 40f;
    public float apperture = 0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy?.ReceiveDamage(damage);
        }
        if (collision.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player?.GetDamaged(damage);
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
