using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class AnchorDistanceManager : MonoBehaviour
{
    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Variables.Object(gameObject).Set("Distance To Anchor", transform.position.x - anchor.transform.position.x);
    }
}
