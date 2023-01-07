using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class PlayerMovement : MonoBehaviour
{
    public float topspeed = 50f;
    public float currentspeed;
    public float accel = .75f;
    public float factor = 0.01f;
    private bool movingopposite;
    private bool directioniszero;
    public Animator animator;
    public SpriteResolver sheathResolver;
    public GameObject weapon;
    public bool attacking;
    public bool canMove = true;
    private bool canDodge = true;
    public StaminaManager staminaManager;
    // Start is called before the first frame update
    void Movement(float direction)
    {
        print(direction);
        if(!attacking && canMove)
        {
            currentspeed += direction * accel;
        }
        Vector3 Motion = new Vector3(currentspeed*factor,0,0);
        transform.position += Motion;
        movingopposite = ((direction == 1 && currentspeed < 0) || (direction == -1 && currentspeed > 0));
        directioniszero = (direction == 0);
        if (directioniszero ^ movingopposite || attacking || !canMove) 
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
        if(currentspeed > topspeed && Input.GetAxisRaw("Run") == 1 && staminaManager.UseStamina(.0075f))
        {
            currentspeed = topspeed;
        }
        if(currentspeed > 0.5f*topspeed && Input.GetAxisRaw("Run") == 0 )
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
        if(!attacking && canMove)
        {
            animator.SetFloat("Speed",currentspeed);
        }
        else
        {
            animator.SetFloat("Speed",0);
        }
        if(!canMove)
        {
            currentspeed = 0;
        }
        if(Input.GetKeyDown("space") && canDodge && staminaManager.UseStamina(1f))
        {
            animator.SetTrigger("Dodge");
            Vector3 Dodge;
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                Dodge = new Vector3(Input.GetAxisRaw("Horizontal")*120, 10, 0);
            }
            else
            {
                Dodge = new Vector3(-120, 10, 0);
            }
            gameObject.GetComponent<Rigidbody2D>().AddForce(Dodge);
            canDodge = false;
            canMove = false;
            StartCoroutine(DodgeDelay());

        }
        
    }
    IEnumerator DodgeDelay()
    {
        yield return new WaitForSeconds(0.35f);
        canDodge = true;
        canMove = true;
    }
}
