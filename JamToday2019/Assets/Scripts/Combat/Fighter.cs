using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public Weapon[] weapons;
    public Health target;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        foreach (Weapon weapon in weapons)
        {
            if (isInRange(target.gameObject, weapon))
            {
                Hit(weapon);
            }

        }
    }


    //Animation Event
    void Hit(Weapon weapon)
    {
        Physics2D.OverlapBox(transform.position, new Vector2(weapon.Range, weapon.Range), 0f);
    }

    //Animation Event
    void Shoot()
    {

    }

    private bool isInRange(GameObject target, Weapon weapon)
    {
        return (target.transform.position - transform.position).magnitude < weapon.Range;
    }
}
