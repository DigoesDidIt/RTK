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
    // Start is called before the first frame update
    void Start()
    {
        distanceToPlayer = 100;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Variables.Object(gameObject).Set("Distance to Player", distanceToPlayer);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(-1*transform.localScale.x, 0),5);
        if (hit.collider.gameObject.tag == "Player")
        {
            canSeePlayer = true;
        }
        else
        {
            canSeePlayer = false;
        }
    }
}
