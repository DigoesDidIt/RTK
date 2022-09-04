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

        targetOffset = playerMovement.currentspeed/100;
        if(offset < targetOffset)
        {
            offset += .002f;    
        }
        else if(offset > targetOffset)
        {
            offset -= .002f;
        }
        transform.position = new Vector3(player.transform.position.x - (offset*3), player.transform.position.y + 3, player.transform.position.z - 10 - Mathf.Abs(offset));
        print("offset = " + offset +". direction is "+ direction + ". Target is " + targetOffset);
    }
}
