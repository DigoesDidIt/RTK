using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class OutsideLayerManager : MonoBehaviour
{
    public Light2D globalLight;
    public bool isInside = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        globalLight.intensity = .8f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
       isInside = false;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        print("outside " + collider.gameObject.tag);
        if (collider.gameObject.tag == "Player")
        {
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            globalLight.intensity = .4f;
            isInside = true;
            collider.gameObject.transform.GetChild(0).GetComponent<CameraController>().goalZOffset = 1.5f;

        }
    }
    void OnTriggerExit2D(Collider2D collider) 
    {
        print("exited" + isInside);
        
        if(!isInside && collider.gameObject.tag == "Player")
        {
            print("was player");
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        globalLight.intensity = .8f;
        collider.gameObject.transform.GetChild(0).GetComponent<CameraController>().goalZOffset = 0;
        }
        
        
    }

}
