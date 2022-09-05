﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator animator;
    public GameObject hurtbox;
    private bool attacking = false;
    public string previousAttack;
    // Start is called before the first frame update
    void LightAttack()
    {
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

    }
    void RunningSlash()
    {
        animator.SetTrigger("RunningSlash");
        StartCoroutine(SlashDelay());
    }

    void Start()
    {
        previousAttack = "None";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j") && !attacking && playerMovement.currentspeed > 25)
        {
            RunningSlash();
        }
        else if(Input.GetKeyDown("j"))// && !attacking)
        {
            LightAttack();
        }
        playerMovement.attacking = attacking;
        if(playerMovement.currentspeed < 25)
        {
            animator.ResetTrigger("RunningSlash");
        }
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
        }
    }
    
}
