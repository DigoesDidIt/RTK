using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideWallManager : MonoBehaviour
{
    public GameObject outsideView;
    // Start is called before the first frame update
    void Start()
    {
        outsideView = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D playerObject)
    {
        if(playerObject.gameObject.tag == "Player")
        {
            outsideView.GetComponent<OutsideLayerManager>().IsPLayerInside(true);
        }
    }
    public void OnTriggerExit2D(Collider2D playerObject)
    {
        if(playerObject.gameObject.tag == "Player")
        {
            outsideView.GetComponent<OutsideLayerManager>().IsPLayerInside(false);
        }
    }
}
