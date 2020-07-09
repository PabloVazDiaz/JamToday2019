﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerToFollow;

    private void Start()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 Playerposition = new Vector3(playerToFollow.transform.position.x, playerToFollow.transform.position.y, -5);
        transform.position = Playerposition;
    }
}
