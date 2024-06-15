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
        player = GameObject.Find("Player");
        eque = GameObject.Find("Enemy Controller").GetComponent<EnemyQueueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 3);
        if(hit.collider != null)
        {
            if(hit.collider.tag == "Player" || hit.collider.gameObject.GetComponent<LOSManager>().canSeePlayer)
            {
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
        Variables.Object(gameObject).Set("Can See Player", canSeePlayer);
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Variables.Object(gameObject).Set("Distance to Player", distanceToPlayer);
        if(distanceToPlayer < 5 && !eque.combatants.Contains(GetComponent<EnemyBehaviorManager>().getEnemy()))
        {
            eque.combatants.Add(GetComponent<EnemyBehaviorManager>().getEnemy());
            eque.setHoverDistances();
        }
    }
}
