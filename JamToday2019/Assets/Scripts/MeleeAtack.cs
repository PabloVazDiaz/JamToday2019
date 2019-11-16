using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    Enemy enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Melee Atack");
        if (collision.tag == "Player")
        {
        print("HitPlayer");   
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player?.GetDamaged(enemy.AttackDamage);
        }
    }
}
