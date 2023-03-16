using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ForegroundDetectionManager : MonoBehaviour
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
    void OnTriggerExit2D(Collider2D collider)
    {
       if(collider.gameObject.tag == "Foreground")
        {
            collider.gameObject.GetComponent<OutsideLayerManager>().Show();
            globalLight.intensity = .8f; 
        } 
        //Hurtbox dissapearing breaks this
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Foreground")
        {
            collider.gameObject.GetComponent<OutsideLayerManager>().Hide();
            globalLight.intensity = .4f;
        }
    }
    
}
