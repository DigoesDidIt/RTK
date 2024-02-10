using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class LOSManager : MonoBehaviour
{
    public float distanceToPlayer;
    public bool canSeePlayer;
    public GameObject player;
    public EnemyQueueSystem eque;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Variables.Object(gameObject).Set("Distance to Player", distanceToPlayer);
        if(distanceToPlayer < 5 && !eque.combatants.Contains(GetComponent<EnemyBehaviorManager>().getEnemy()))
        {
            eque.combatants.Add(GetComponent<EnemyBehaviorManager>().getEnemy());
        }
    }
}
