using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float offset;
    public float targetOffset;
    public GameObject player;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            direction = Input.GetAxisRaw("Horizontal");
        }

        targetOffset = Mathf.Abs(playerMovement.currentspeed/100);
        if(targetOffset > 0 && offset < targetOffset)
        {
            offset += .001f;    
        }
        else if(offset > targetOffset)
        {
            offset -= .001f;
        }
        transform.position = new Vector3(player.transform.position.x - (offset*direction), player.transform.position.y + 3, player.transform.position.z - 10);
        print("offset = " + offset +". direction is "+ direction + ". Target is " + targetOffset);
    }
}
