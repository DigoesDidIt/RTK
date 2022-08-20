using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class PlayerMovement : MonoBehaviour
{
    public float topspeed = 50f;
    public float currentspeed;
    public float accel = 1f;
    public float factor = 0.01f;
    private bool movingopposite;
    private bool directioniszero;
    public Animator animator;
    public SpriteResolver sheathResolver;
    public GameObject weapon;
    // Start is called before the first frame update
    void Movement(float direction)
    {
        print(direction);
        currentspeed += direction * accel;
        Vector3 Motion = new Vector3(currentspeed*factor,0,0);
        transform.position += Motion;
        movingopposite = ((direction == 1 && currentspeed < 0) || (direction == -1 && currentspeed > 0));
        directioniszero = (direction == 0);
        if (directioniszero ^ movingopposite) 
        {
            if(Mathf.Abs(currentspeed) <= 1)
            {
                currentspeed = 0;
            }
            else if(currentspeed > 0)
            {
                currentspeed -= accel*3;
            }
            else
            {
                currentspeed += accel*3;
            }
        }
        if(currentspeed > topspeed && Input.GetAxisRaw("Run") == 1)
        {
            currentspeed = topspeed;
        }
        if(currentspeed > 0.5f*topspeed && Input.GetAxisRaw("Run") == 0)
        {
            currentspeed = 0.5f*topspeed;
        }
        if(currentspeed < -0.5f*topspeed)
        {
            currentspeed = -0.5f*topspeed;
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Speed",currentspeed);
        if(Mathf.Abs(currentspeed) >25)
        {
            sheathResolver.SetCategoryAndLabel("Sheaths", "Sheathed");
            weapon.SetActive(false);
        }
        else
        {
            sheathResolver.SetCategoryAndLabel("Sheaths", "Unsheathed");
            weapon.SetActive(true);
        }
    }
}
