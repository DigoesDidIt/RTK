using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class HealthManager : MonoBehaviour
{
    public float health;
    public AttackManager attackManager;
    public StaminaManager staminaManager;
    private bool Invul;
    public bool blocking;
    public bool parry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Variables.Object(gameObject).Set("Health", health);
        
        if(attackManager.IsBlocking == true && !(blocking == true || parry == true))
        {
            parry = true;
            StartCoroutine(ParryTimer());
            blocking = true;

        }
        else if(attackManager.IsBlocking == false)
        {
            parry = false;
            blocking = false;
        }
    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false && blocking == false && !parry)
        {
            health -= 1;
            Invul = true;
            StartCoroutine(InvulFrames());
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false && blocking == false && !parry)
        {
            health -= 1;
            Invul = true;
            StartCoroutine(InvulFrames());
        }
        else if (hurtbox.gameObject.tag == "Special Attack" && Invul == false && !parry)
        {
            health -= 1;
            Invul = true;
            StartCoroutine(InvulFrames());
        }
        else if((hurtbox.gameObject.tag == "Light Attack" || hurtbox.gameObject.tag == "Heavy Attack") && blocking && !parry)
        {
            staminaManager.UseStamina(2f);
            hurtbox.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Blocked");
            if(staminaManager.stamina <= 0)
            {
                attackManager.animator.SetTrigger("BlockBreak");
                attackManager.IsBlocking = false;
            }
        }
        else if((hurtbox.gameObject.tag == "Light Attack" || hurtbox.gameObject.tag == "Heavy Attack" || hurtbox.gameObject.tag == "Special Attack") && parry)
        {
            staminaManager.UseStamina(-2f);
            hurtbox.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Stunned");
            attackManager.animator.SetBool("Parry", true);
            Variables.Object(hurtbox.transform.parent.transform.parent.gameObject).Set("Stunned", true);
        }

        
    }
    IEnumerator InvulFrames()
    {
        yield return new WaitForSeconds(.25f);
        Invul = false;
    }
    IEnumerator ParryTimer()
    {
        yield return new WaitForSeconds(.3f);
        parry = false;
        attackManager.animator.SetBool("Parry", false);

    }
}
