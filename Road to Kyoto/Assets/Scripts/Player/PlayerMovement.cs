using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Movement(float direction)
    {
        print(direction);
        Vector2 Motion = new Vector2(speed*direction,0);
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(Input.GetAxisRaw("Horizontal"));
    }
}
