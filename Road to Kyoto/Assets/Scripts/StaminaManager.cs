using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public float stamina;
    public float visualStamina;
    public bool canRegenTiredStamina;
    public bool isRegeningTiredStamina;
    public bool canRegenStamina;
    // Start is called before the first frame update
    void Start()
    {
        stamina = 10;
        canRegenTiredStamina = false;
        canRegenStamina = true;
    }

    // Update is called once per frame
    void Update()
    {
        stamina = Mathf.Max(stamina, 0);
        if(stamina != 0)
        {
            visualStamina = stamina;
            if (canRegenStamina && stamina <= 10)
            {
                stamina += 0.05f;
                stamina = Mathf.Min(stamina, 10);
            }
        }
        else if(!isRegeningTiredStamina)
        {
            StartCoroutine(TiredDelay());
        }
        if(canRegenTiredStamina)
        {
            visualStamina += 0.05f;
            print("hello");
            if(visualStamina >= 10)
            {
                stamina = 10;
                visualStamina = 10;
                isRegeningTiredStamina = false;
                canRegenTiredStamina = false;
                print("awesome");
            }
        }
    }
    public bool UseStamina(float staminaLoss)
    {
        if(stamina != 0)
        {
            stamina -= staminaLoss;
            canRegenStamina = false;
            StartCoroutine(StaminaRegenDelay(stamina));
            return true;
        }
        return false;
        
    }
    IEnumerator StaminaRegenDelay(float previousStamina)
    {
        yield return new WaitForSeconds(2);
        if (stamina == previousStamina)
        {
            canRegenStamina = true;
        }
    }
    IEnumerator TiredDelay()
    {
        visualStamina = 0;
        isRegeningTiredStamina = true;
        yield return new WaitForSeconds(2);
        canRegenTiredStamina = true;
    }
}
