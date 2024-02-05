using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private string enemyType;
    private int enemyTier;
    private int enemyHealth;
    private int enemyBlock;
    public Enemy(string type, int tier)
    {
        this.enemyType = type;
        this.enemyTier = tier;
        switch (enemyType)
        {
            case "Swordsman":
                if(tier == 1)
                {
                    enemyHealth = 3;
                    enemyBlock = 4;
                }
                break;
            default: //unemployed
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
