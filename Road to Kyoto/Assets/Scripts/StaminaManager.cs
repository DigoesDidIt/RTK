using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public float stamina;
    public float visualStamina;
    public bool canRegenTiredStamina;
    // Start is called before the first frame update
    void Start()
    {
        stamina = 10;
        canRegenTiredStamina = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StaminaRegenDelay(stamina));
        stamina = Mathf.Max(stamina, 0);
        if(visualStamina != 0)
        {
            visualStamina = stamina;
        }
        else
        {
            StartCoroutine(TiredDelay());
        }
        if(canRegenTiredStamina)
        {
            visualStamina += 0.05f;
            if(visualStamina >= 10)
            {
                stamina = 10;
                canRegenTiredStamina = false;
            }
        }
    }
    public void UseStamina(float staminaLoss)
    {
        stamina -= staminaLoss;
    }
    IEnumerator StaminaRegenDelay(float currentStamina)
    {
        yield return new WaitForSeconds(2);
        if(stamina >= currentStamina && stamina < 10 && stamina != 0)
        {
            stamina += .05f;
            stamina = Mathf.Min(stamina, 10);
        }

    }
    IEnumerator TiredDelay()
    {
        yield return new WaitForSeconds(2);
        canRegenTiredStamina = true;
    }
}
