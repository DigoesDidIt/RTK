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
    public float towardsPlayer;
    public EnemyHealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        eque = GameObject.Find("Enemy Controller").GetComponent<EnemyQueueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.getHealth() <= 0)
        {
            return;
        }
        float direction = transform.localScale.x;
        Vector2 headHeight = new Vector2(transform.position.x+.5f*direction,transform.position.y+1.5f);
        RaycastHit2D hit = Physics2D.Raycast(headHeight, Vector2.right*direction, 10);
        //Debug.DrawRay(headHeight, Vector2.left, Color.red, 10f);
        if(hit.collider != null)
        {
            if(hit.collider.tag == "Player")
            {
                canSeePlayer = true;
            }
            else if(hit.collider.tag == "Enemy" && hit.collider.gameObject.GetComponent<LOSManager>().canSeePlayer)
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
        towardsPlayer = (player.transform.position.x - transform.position.x)/Mathf.Abs(player.transform.position.x - transform.position.x);
        Variables.Object(gameObject).Set("Towards Player", towardsPlayer);

        if((distanceToPlayer < 2.5 || canSeePlayer) && !eque.combatants.Contains(GetComponent<EnemyBehaviorManager>().getEnemy()))
        {
            transform.localScale = new Vector3(towardsPlayer, 1, 1);
            eque.combatants.Add(GetComponent<EnemyBehaviorManager>().getEnemy());
            eque.setHoverDistances();
        }

    }
}
