using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName = "Weapons/ New Weapon")]
public class Weapon : ScriptableObject
{
    public float FireCoolDown;
    public float projectileSpeed;
    public float Damage;
    public float Range;

    public Sprite projectileSprite;
}
