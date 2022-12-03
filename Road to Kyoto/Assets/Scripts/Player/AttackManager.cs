using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public StaminaManager staminaManager;
    public Animator animator;
    public GameObject hurtbox;
    private bool attacking = false;
    public string previousAttack;
    public float attackDecay;
    public bool IsBlocking;
    
    // Start is called before the first frame update
    void LightAttack()
    {
        if(staminaManager.stamina > 0)
            staminaManager.UseStamina(1.5f);
            hurtbox.tag = "Light Attack";
            if(previousAttack == "None")
            {
                attacking = true;
                //animator.ResetTrigger("Light2");
                //animator.ResetTrigger("Light3");
                playerMovement.currentspeed += -15;
                animator.SetTrigger("Light1");
                StartCoroutine(Light1Delay());  
                previousAttack = "Light1";
            }
            else if(previousAttack == "Light1")
            {
                attacking = true;
                //animator.ResetTrigger("Light1");
                //animator.ResetTrigger("Light3");
                animator.SetTrigger("Light2");
                previousAttack = "Light2";

            }
            else if(previousAttack == "Light2")
            {
                attacking = true;
                //animator.ResetTrigger("Light1");
                //animator.ResetTrigger("Light2");
                animator.SetTrigger("Light3");
                previousAttack = "None";
                
            }
            StartCoroutine(StartAttackCooldown(previousAttack));
            attackDecay = 0;
    }
    void HeavyAttack()
    {
        hurtbox.tag = "Heavy Attack";
        animator.SetTrigger("Heavy");
        attackDecay = 0;
        attacking = true;
        StartCoroutine(HeavyDelay());
        StartCoroutine(StartAttackCooldown(previousAttack));
    }
    void RunningSlash()
    {
        hurtbox.tag = "Heavy Attack";
        animator.SetTrigger("RunningSlash");
        StartCoroutine(SlashDelay());
    }

    void Start()
    {
        previousAttack = "None";
        attackDecay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("j") || Input.GetKeyDown("k"))  && !attacking && playerMovement.currentspeed > 25)
        {
            RunningSlash();
        }
        else if(Input.GetKeyDown("j"))// && !attacking)
        {
            LightAttack();
        }
        if(Input.GetKeyDown("k"))
        {
            HeavyAttack();
        }
        else if(playerMovement.currentspeed < 25)
        {
            animator.ResetTrigger("RunningSlash");
        }
        if(attackDecay < 1)
        {
            attackDecay +=.025f;
        }
        playerMovement.attacking = (attacking || IsBlocking);
        if(Input.GetKey("l"))
        {
            IsBlocking = true;
            print("Blocking");
        }
        else
        {
            IsBlocking = false;
        }
        animator.SetBool("IsBlocking", IsBlocking);
    }

    IEnumerator Light1Delay()
    {
        yield return new WaitForSeconds(0.2f);
        playerMovement.currentspeed += 15;
        yield return new WaitForSeconds(0.5f);
        attacking = false;
    }
    IEnumerator SlashDelay()
    {
        yield return new WaitForSeconds(.4f);
        attacking = true;
        yield return new WaitForSeconds(.5f);
        attacking = false;
    }
    IEnumerator StartAttackCooldown(string pa)
    {
        yield return new WaitForSeconds(.7f);
        if(previousAttack == pa)
        {
            previousAttack = "None";
            attacking = false;
            animator.ResetTrigger("Light1");
            animator.ResetTrigger("Light2");
            animator.ResetTrigger("Light3");
            animator.ResetTrigger("Heavy");
        }
    }
    IEnumerator HeavyDelay()
    {
        yield return new WaitForSeconds(0.8f);
        attacking = false;
    }
    
}
