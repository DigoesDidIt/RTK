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
    public float goalZOffset;
    public float zOffset;
    public bool freeze;
    // Start is called before the first frame update
    void Start()
    {
        goalZOffset = 0;
        zOffset = 0;
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
        if(targetOffset == 0 && Mathf.Abs(offset)<=.003)
        {
            offset=0;
        }
        if(goalZOffset > zOffset)
        {
            zOffset += .1f;
        }
        if(goalZOffset < zOffset && !freeze)
        {
            zOffset -= .1f;
        }
        transform.position = new Vector3(player.transform.position.x - (offset*3), player.transform.position.y + 3, player.transform.position.z - 10 - Mathf.Abs(offset) + zOffset);
        //print("offset = " + offset +". direction is "+ direction + ". Target is " + targetOffset);
    }
}
