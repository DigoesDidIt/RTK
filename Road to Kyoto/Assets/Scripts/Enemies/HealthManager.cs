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
    public PlayerMovement playermovement;

    public CameraController cameraController;
    private bool Invul;
    public bool blocking;
    public bool perfectParry;
    public bool parry;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Variables.Object(gameObject).Set("Health", health);
        
        if(attackManager.IsBlocking == true && !(blocking == true || parry == true))
        {
            perfectParry = true;
            StartCoroutine(ParryTimer());
            blocking = true;

        }
        else if(attackManager.IsBlocking == false)
        {
            parry = false;
            perfectParry = false;
            blocking = false;
        }
        
    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false && blocking == false && !parry && !perfectParry)
        {
            health -= 1;
            Invul = true;
            StartCoroutine(InvulFrames());
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false && blocking == false && !parry && !perfectParry)
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
        else if((hurtbox.gameObject.tag == "Light Attack" || hurtbox.gameObject.tag == "Heavy Attack") && blocking && !parry && !perfectParry)
        {
            staminaManager.UseStamina(2f);
            hurtbox.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Blocked");
            if(staminaManager.stamina <= 0)
            {
                attackManager.animator.SetTrigger("BlockBreak");
                attackManager.IsBlocking = false;
            }
        }
        else if((hurtbox.gameObject.tag == "Light Attack" || hurtbox.gameObject.tag == "Heavy Attack") && perfectParry)
        {
            staminaManager.UseStamina(-2f);
            hurtbox.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Stunned");
            attackManager.animator.SetBool("Parry", true);
            Variables.Object(hurtbox.transform.parent.transform.parent.gameObject).Set("Stunned", 2.5f);
            transform.Find("Sparks").GetComponent<ParticleSystem>().Play();
            cameraController.goalZOffset = 1.2f;
            cameraController.freeze = true;
            StartCoroutine(PerfectParry());
        }
        else if ((hurtbox.gameObject.tag == "Light Attack" || hurtbox.gameObject.tag == "Heavy Attack") && parry)
        {
            hurtbox.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Stunned");
            attackManager.animator.SetBool("Parry", true);
            Variables.Object(hurtbox.transform.parent.transform.parent.gameObject).Set("Stunned", 1.5f);
        }
        if(health<=0)
        {
            death();
        }


    }
    void death()
    {
        playermovement.canMove = false;
        attackManager.animator.SetTrigger("Death");
    }
    IEnumerator InvulFrames()
    {
        yield return new WaitForSeconds(.25f);
        Invul = false;
    }
    IEnumerator ParryTimer()
    {
        yield return new WaitForSeconds(.1f);
        perfectParry = false;
        parry = true;
        yield return new WaitForSeconds(.35f);
        attackManager.animator.SetBool("Parry", false);
        parry = false;
    }
    IEnumerator PerfectParry()
    {
        yield return new WaitForSeconds(2.5f);
        cameraController.goalZOffset = 0;
        cameraController.freeze = false;
    }
}
