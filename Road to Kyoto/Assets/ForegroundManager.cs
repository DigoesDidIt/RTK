﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onCollisionEnter2D(Collider2D collider)
    {
        if(collider.tag == "Foreground")
        {
            
        }
        print(collider.name);
    }
    void onTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Foreground")
        {
            
        }
        print(collider.name);
    }
}
