using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class EnemyBehaviorManager : MonoBehaviour
{
    public string currentBehavior;
    public LOSManager losManager;
    public HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        currentBehavior = "Idling";
    }

    // Update is called once per frame
    void Update()
    {
        if(losManager.distanceToPlayer < 5 && currentBehavior == "Idling")
        {
            currentBehavior = "Engaged";
        }
        if(healthManager.health <= 0)
        {
            currentBehavior = "Dead";
        }
    }
}
