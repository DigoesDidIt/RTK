using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideLayerManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

    }
    public void Hide()
    {
       foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }  
    }
    public void Show()
    {
       foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }  
    }
    

}
