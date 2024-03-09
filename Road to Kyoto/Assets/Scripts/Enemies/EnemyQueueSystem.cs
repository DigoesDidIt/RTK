using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueueSystem : MonoBehaviour
{
    public List<Enemy> combatants = new List<Enemy>();
    private float hoverStart = 4;
    private float hoverEnd = 7;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 9);
        Physics2D.IgnoreLayerCollision(9, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Ememies: " + combatants.Count);
    }
    void FixedUpdate()
    {
        if(!MapActive(combatants).Contains(true))
        {
            int i = UnityEngine.Random.Range(0,combatants.Count);
            combatants[i].setActive(true); 
            setHoverDistances();
        }
    }
    List<bool> MapActive(List<Enemy> enemyList)
    {
        List<bool> list= new List<bool>();
        foreach(Enemy e in enemyList)
        {
            list.Add(e.getActive());
        }
        return list;
    }
    int TotalNonCombatants(List<Enemy> enemyList)
    {
        int total = 0;
        foreach(Enemy e in enemyList)
        {
            if(!e.getActive())
            {
                total++;
            }
        }
        return total;
    }
    public void setHoverDistances()
    {
        float  spacing = 0;
        foreach(Enemy e in combatants)
        {
            if(!e.getActive())
            {
                e.setHoverDist(hoverStart + spacing);
                spacing += (hoverEnd-hoverStart)/TotalNonCombatants(combatants);
            }
        }
    }
}
