using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class EnemyBehaviorManager : MonoBehaviour
{
    private Enemy self;
    public string type;
    public int tier;
    // Start is called before the first frame update
    void Start()
    {
        self = new Enemy(type,tier);
        GetComponent<EnemyHealthManager>().setHealth(self.getHealth());
        GetComponent<EnemyHealthManager>().setBlock(self.getBlock());
        Variables.Object(gameObject).Set("Tier", tier);
        Variables.Object(gameObject).Set("Max Hp", self.getHealth());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Enemy getEnemy()
    {
        return self;
    }
}
