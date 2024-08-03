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
    public bool active;
    public bool waiting;

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
        active = self.getActive();
        Variables.Object(gameObject).Set("Active", active);
        if(active && !waiting)
        {
            waiting = true;
            StartCoroutine(activeTimer());
        }
        Variables.Object(gameObject).Set("Hover Distance", self.getHoverDist());
    }
    public Enemy getEnemy()
    {
        return self;
    }
    public void setActive(bool b)
    {
        self.setActive(b);
    }
    IEnumerator activeTimer()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(5,10));
        self.setActive(false);
        active = false;
        waiting = false;
        Debug.Log("done!");
    }

}
