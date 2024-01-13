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
    public bool IsChargingSpecial;
    public bool IsSpecialReady;
    public ParticleSystem swordTrail;
    private Gradient grad = new Gradient();
    private GradientColorKey[] blackToRed = { new GradientColorKey(Color.black, 0), new GradientColorKey(Color.red, 1) };
    private GradientAlphaKey[] solidToTransparent = { new GradientAlphaKey(1, 0), new GradientAlphaKey(0, 1) };
    private GradientColorKey[] blackToWhite = { new GradientColorKey(Color.black, 0), new GradientColorKey(Color.white, 1) };
    private IEnumerator chargedelay;

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
    void SpecialAttack()
    {
        hurtbox.tag = "Special Attack";
        
        
        animator.SetBool("ChargingSp", false);
        IsChargingSpecial = false;
        IsSpecialReady = false;
        StartCoroutine(SpecialDelay());
        StartCoroutine(StartAttackCooldown(previousAttack));
    }

    void Start()
    {
        previousAttack = "None";
        grad.SetKeys(blackToWhite, solidToTransparent);
        var cot = swordTrail.GetComponent<ParticleSystem>().trails;
        cot.colorOverLifetime = grad;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("j"))
        {
            attackQueue.Add("j");
        }
        if (Input.GetKeyDown("k") && staminaManager.stamina != 0)
        {
            IsChargingSpecial = false;
            IsSpecialReady = false;
            chargedelay = ChargeDelay();
            StartCoroutine(chargedelay);
        }
        if (Input.GetKeyUp("k") && !IsChargingSpecial)
        {
            attackQueue.Add("k");
        }
        if(Input.GetKeyUp("k") && IsSpecialReady && staminaManager.UseStamina(2.5f))
        {
            SpecialAttack();
        }
        if((Input.GetKeyUp("k") && IsChargingSpecial && !IsSpecialReady)||(Input.GetKeyUp("k") && IsSpecialReady && !staminaManager.UseStamina(2.5f)))
        {
            animator.SetBool("ChargingSp", false);
            IsChargingSpecial = false;
            attacking = false;
            IsSpecialReady = false;
            animator.SetBool("Special", false);
            StopCoroutine(chargedelay);
            
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
            else if(attackQueue[0] == "k" && !attacking)
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
        if(Input.GetKey("l") && staminaManager.stamina != 0)
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
        yield return new WaitForSeconds(0.4f);
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
        yield return new WaitForSeconds(.6f);
        attacking = false;
    }
    IEnumerator ChargeDelay()
    {
        yield return new WaitForSeconds(.20f);
        if(Input.GetKey("k"))
        {
            attacking = true;
            IsChargingSpecial = true;
            attackQueue.Clear();
            animator.SetBool("ChargingSp", true);
            yield return new WaitForSeconds(1.30f);
            if(IsChargingSpecial)
            {
                IsSpecialReady = true;
                animator.SetBool("Special",true);
                grad.SetKeys(blackToRed,solidToTransparent);
                var cot = swordTrail.GetComponent<ParticleSystem>().trails;
                cot.colorOverLifetime = grad;
            }
            
        }
        
    }
    IEnumerator SpecialDelay()
    {
        yield return new WaitForSeconds(.8f);
        attacking = false;
        animator.SetBool("Special",false);
        grad.SetKeys(blackToWhite, solidToTransparent);
        var cot = swordTrail.GetComponent<ParticleSystem>().trails;
        cot.colorOverLifetime = grad;
    }

}
