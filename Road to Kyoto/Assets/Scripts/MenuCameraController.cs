using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    float scaler = .001f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float xoff = mousePos.x - Screen.width/2;
        float yoff = mousePos.y - Screen.height/2;
        //Debug.Log(xoff + ", " + yoff);
        transform.position = new Vector3(xoff * scaler, yoff * scaler, -10);

    }
}
