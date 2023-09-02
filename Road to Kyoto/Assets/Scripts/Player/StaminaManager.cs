using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public float stamina;
    public float visualStamina;
    public bool canRegenTiredStamina;
    public bool isRegeningTiredStamina;
    public bool canRegenStamina;
    public Slider staminaslider;
    private ColorBlock cb;
    // Start is called before the first frame update
    void Start()
    {
        stamina = 10;
        canRegenTiredStamina = false;
        canRegenStamina = true;
        cb = staminaslider.colors;
        cb.disabledColor = new Color(1f, 102f/255f, 102f/255f, 1);
        staminaslider.colors = cb;
    }

    // Update is called once per frame
    void Update()
    {
        
        stamina = Mathf.Max(stamina, 0);
        stamina = Mathf.Min(stamina, 10);
        if(stamina != 0)
        {
            if(stamina < visualStamina)
            {
            visualStamina -= 0.08f;
            }
            if(stamina > visualStamina)
            {
            visualStamina += 0.08f;
            }
            if(Mathf.Abs(stamina-visualStamina) <=.05)
            {
                visualStamina = stamina;
            }
            if (canRegenStamina && stamina <= 10)
            {
                stamina += 0.05f;
                stamina = Mathf.Min(stamina, 10);
            }
        }
        else if(!isRegeningTiredStamina)
        {

            if(visualStamina <= 0)
            {
                StartCoroutine(TiredDelay());
                cb.disabledColor = new Color(92f/255f, 87f/255f, 87f/255f, .4f);
                staminaslider.colors = cb;
            }
            else
            {
                visualStamina -= .08f;
            }
        }
        if(canRegenTiredStamina)
        {
            visualStamina += 0.05f;
            if(visualStamina >= 10)
            {
                stamina = 10;
                visualStamina = 10;
                cb.disabledColor = new Color(255f/255f, 102f/255f, 102f/255f, 1);
                staminaslider.colors = cb;
                isRegeningTiredStamina = false;
                canRegenTiredStamina = false;
            }

        }
        staminaslider.value = visualStamina;


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
