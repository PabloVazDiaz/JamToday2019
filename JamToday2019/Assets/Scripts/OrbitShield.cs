using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitShield : MonoBehaviour
{
    public GameObject Boss;
    public float speed;
    void Update()
    {
        transform.RotateAround(Boss.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
