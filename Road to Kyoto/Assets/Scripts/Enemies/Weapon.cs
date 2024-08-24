using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage = 1;
    private float engagementRange = 1.5;
    private bool blockable = true;
    // Start is called before the first frame update
    public Weapon()
    {
        return;
    }
    public Weapon(float damage)
    {
        this.damage = damage;
    }
    public Weapon(float damage, float engagementRange)
    {
        this.damage = damage;
        this.engagementRange = engagementRange;
    }
    public Weapon(float damage, float engagementRange, bool blockable)
    {
        this.damage = damage;
        this.engagementRange = engagementRange;
        this.blockable = blockable;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float getDamage()
    {
        return damage;
    }
    public float getEngagementRange()
    {
        return engagementRange;
    }
    public float getBlockable()
    {
        return blockable;
    }
}
