using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Melee,
    Ranged
}

[CreateAssetMenu(fileName ="Weapon", menuName = "Weapons/ New Weapon")]
public class Weapon : ScriptableObject
{
    public float FireCoolDown;
    public float TimeLastFired = 0;
    public float projectileSpeed;
    public int Damage;
    public int Ammo;
    public float Range;
    public float Force;
    public WeaponType type;
    public Projectile[] projectiles;

    public Sprite projectileSprite;

}
