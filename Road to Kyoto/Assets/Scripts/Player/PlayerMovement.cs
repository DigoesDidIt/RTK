using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class PlayerMovement : MonoBehaviour
{
    public float topspeed = 75f;
    public float currentspeed;
    public float accel = .4f;
    public float factor = 0.0012f;
    private bool movingopposite;
    private bool directioniszero;
    public Animator animator;
    public SpriteResolver sheathResolver;
    public GameObject weapon;
    public bool attacking;
    public bool blocking;
    public bool canMove = true;
    private bool canDodge = true;
    public StaminaManager staminaManager;
    public bool EnemiesLeft;
    public bool EnemiesRight;
    public bool inCombat;
    public int facing;
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
        if(blocking)
        {
            topspeed = 30f;
        }
        else
        {
            topspeed = 75f;
        }
        if(currentspeed > topspeed && Input.GetAxisRaw("Run") == 1 && staminaManager.UseStamina(.0075f)) //Caps running speed right
        {
            currentspeed = topspeed;
        }
        if(currentspeed > 0.5f*topspeed && Input.GetAxisRaw("Run") == 0) //caps walking speed right
        {
            currentspeed = 0.5f*topspeed;
        }
        if (currentspeed < -1*topspeed && Input.GetAxisRaw("Run") == 1 && staminaManager.UseStamina(.0075f) && !inCombat) // caps running speed lef
        {
            currentspeed = -1*topspeed;
        }
        if (currentspeed < -0.5f*topspeed && Input.GetAxisRaw("Run") == 0) // caps walking speed left
        {
            currentspeed = -0.5f*topspeed;
        }
        if((currentspeed > 0  && (direction == 1) && (!inCombat || (EnemiesLeft && EnemiesRight) ))|| (EnemiesRight && !EnemiesLeft))
        {
            transform.localScale = new Vector3(1,1,1);
            facing = 1;
        }
        else if((currentspeed < 0 && (direction == -1) && (!inCombat || (EnemiesLeft && EnemiesRight) ))|| (EnemiesLeft && !EnemiesRight))
        {
            transform.localScale= new Vector3(-1, 1, 1);
            facing = -1;
        }
        
    }

    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Movement(Input.GetAxisRaw("Horizontal"));
        animator.SetInteger("Direction", facing);
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
        Vector2 headHeight = new Vector2(transform.position.x+.5f,transform.position.y+1.5f);
        RaycastHit2D combatCheckRight = Physics2D.Raycast(headHeight, Vector2.right, 6f, LayerMask.GetMask("Enemy"));
        RaycastHit2D combatCheckLeft = Physics2D.Raycast(headHeight, Vector2.left, 6f, LayerMask.GetMask("Enemy"));
        Debug.DrawRay(headHeight, Vector2.right, Color.cyan, 6f);
        if(combatCheckRight.collider != null && (combatCheckRight.collider.tag == "Enemy" || combatCheckRight.collider.tag == "Heavy Attack" || combatCheckRight.collider.tag == "Light Attack"))
        {
            EnemiesRight = true;
        }
        else
        {
            EnemiesRight = false;
        }
        if(combatCheckLeft.collider != null && (combatCheckLeft.collider.tag == "Enemy" || combatCheckLeft.collider.tag == "Heavy Attack" || combatCheckLeft.collider.tag == "Light Attack"))
        {
            EnemiesLeft = true;
        }
        else
        {
            EnemiesLeft = false;
        }
        if(EnemiesLeft || EnemiesRight)
        {
            inCombat = true;
        }
        else
        {
            inCombat = false;
            Debug.Log("No One");
        }
        animator.SetBool("InCombat", inCombat);

    }
    IEnumerator DodgeDelay()
    {
        yield return new WaitForSeconds(0.35f);
        canDodge = true;
        canMove = true;
    }
}
