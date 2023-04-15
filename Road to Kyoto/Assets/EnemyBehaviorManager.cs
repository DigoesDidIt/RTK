using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class EnemyBehaviorManager : MonoBehaviour
{
    public string currentBehavior;
    // Start is called before the first frame update
    void Start()
    {
        currentBehavior = "Attacking";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
