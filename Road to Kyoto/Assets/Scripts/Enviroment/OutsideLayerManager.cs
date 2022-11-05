using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class OutsideLayerManager : MonoBehaviour
{
    public Light2D globalLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onTriggerEnter2D(Collider2D collider)
    {
        print("outside " + collider.tag);
        if(collider.tag == "Player")
        {
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            globalLight.intensity = .4f;

        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            globalLight.intensity = 1;
        }
    }
    
}
