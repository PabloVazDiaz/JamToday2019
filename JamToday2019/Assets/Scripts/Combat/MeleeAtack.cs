using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    Enemy enemy;
    public Sprite[] attackSprites;
    Sprite originalSprite;
    int attackDamage;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        originalSprite = enemy.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(AtackAnimation());
            Health target = collision.gameObject.GetComponent<Health>();
            target?.TakeDamage(gameObject, attackDamage);
        }
    }

    private IEnumerator AtackAnimation()
    {
        foreach (Sprite sprite in attackSprites)
        {
            enemy.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            yield return new WaitForSeconds(0.15f);
        }
        enemy.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = originalSprite;

    }
}
