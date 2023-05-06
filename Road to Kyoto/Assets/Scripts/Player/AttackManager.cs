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
    public bool IsBlocking;
    public List<string> attackQueue;
    
    // Start is called before the first frame update
    void LightAttack()
    {
        if (staminaManager.UseStamina(1.5f))
        {
            hurtbox.tag = "Light Attack";
            if (previousAttack == "None")
            {
                attacking = true;
                //animator.ResetTrigger("Light2");
                //animator.ResetTrigger("Light3");
                animator.SetTrigger("Light1");
                StartCoroutine(Light1Delay());
                previousAttack = "Light1";
            }
            else if (previousAttack == "Light1")
            {
                attacking = true;
                //animator.ResetTrigger("Light1");
                //animator.ResetTrigger("Light3");
                animator.SetTrigger("Light2");
                StartCoroutine(Light1Delay());
                previousAttack = "Light2";

            }
            else if (previousAttack == "Light2")
            {
                attacking = true;
                //animator.ResetTrigger("Light1");
                //animator.ResetTrigger("Light2");
                animator.SetTrigger("Light3");
                StartCoroutine(Light1Delay());
                previousAttack = "None";

            }
            StartCoroutine(StartAttackCooldown(previousAttack));
        }
    }
    void HeavyAttack()
    {
        if (staminaManager.UseStamina(2f))
        {
            hurtbox.tag = "Heavy Attack";
            animator.SetTrigger("Heavy");
            attacking = true;
            StartCoroutine(HeavyDelay());
            StartCoroutine(StartAttackCooldown(previousAttack));
        }
    }
    void RunningSlash()
    {
        if (staminaManager.UseStamina(1.5f))
        {
            hurtbox.tag = "Heavy Attack";
            animator.SetTrigger("RunningSlash");
            StartCoroutine(SlashDelay());
        }
    }

    void Start()
    {
        previousAttack = "None";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            attackQueue.Add("j");
        }
        if (Input.GetKeyDown("k"))
        {
            attackQueue.Add("k");
        }
        if(attackQueue.Count > 0)
        {
            if (!attacking && (playerMovement.currentspeed > 37.5 || playerMovement.currentspeed < -37.5))
            {
                RunningSlash();
                attackQueue.RemoveAt(0);
            }
            else if(attackQueue[0] == "j" && !attacking)
            {
                LightAttack();
                attackQueue.RemoveAt(0);
            }
            if(attackQueue[0] == "k" && !attacking)
            {
                HeavyAttack();
                attackQueue.RemoveAt(0);
            }
        }
            
        else if(playerMovement.currentspeed < 37.5)
        {
            animator.ResetTrigger("RunningSlash");
        }
        playerMovement.attacking = (attacking);
        playerMovement.blocking = (IsBlocking);
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
        yield return new WaitForSeconds(0.6f);
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
        yield return new WaitForSeconds(1.2f);
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
        yield return new WaitForSeconds(.8f);
        attacking = false;
    }
    
}
