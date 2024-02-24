using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueueSystem : MonoBehaviour
{
    public List<Enemy> combatants = new List<Enemy>();
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
}
