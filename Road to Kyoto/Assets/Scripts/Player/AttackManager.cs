using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator animator;
    public GameObject hurtbox;
    private bool attacking = false;
    // Start is called before the first frame update
    void LightAttack()
    {
        hurtbox.tag = "Light Attack";
        attacking = true;
        playerMovement.currentspeed += -15;
        animator.SetTrigger("Light1");
        StartCoroutine(LightDelay());

    }
    void RunningSlash()
    {
        animator.SetTrigger("RunningSlash");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j") && !attacking && playerMovement.currentspeed > 25)
        {
            RunningSlash();
        }
        else if(Input.GetKeyDown("j") && !attacking)
        {
            LightAttack();
        }
        playerMovement.attacking = attacking;
    }

    IEnumerator LightDelay()
    {
        yield return new WaitForSeconds(0.2f);
        playerMovement.currentspeed += 15;
        yield return new WaitForSeconds(0.5f);
        attacking = false;
    }
}
