using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private string enemyType;
    private int enemyTier;
    private int enemyHealth;
    private int enemyBlock;
    private bool activated = false;
    private float hoverDist = 4;
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
                else if(tier == 2)
                {
                    enemyHealth = 4;
                    enemyBlock = 6;
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
    public int getHealth()
    {
        return enemyHealth;
    }
    public int getBlock()
    {
        return enemyBlock;
    }
    public bool getActive()
    {
        return activated;
    }
    public void setActive(bool b)
    {
        activated = b;
    }
    public void setHoverDist(float f)
    {
        hoverDist = f;
    }
    public float getHoverDist()
    {
        return hoverDist;
    }
}
