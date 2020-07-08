using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackType
{
    Melee,
    Ranged
}

public class Attack : ScriptableObject
{

    [SerializeField] int Damage;
    [SerializeField] float CoolDown;
    [SerializeField] float Range;
    [SerializeField] float Force; 
    [SerializeField] AttackType Type;

    
}
