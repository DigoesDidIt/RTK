﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSManager : MonoBehaviour
{
    public float distanceToPlayer;
    public bool canSeePlayer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
    }
}
