using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;
using UnityEngine.UI;
//[IncludeInSettings(true)];
public class EnemyHealthManager : MonoBehaviour
{
    private float health;
    private bool Invul;
    public bool blocking;
    public Slider blockSlider;

    private int blockMeter;
    private int blockMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Variables.Object(gameObject).Set("Health", health);
        blocking = transform.GetChild(0).GetComponent<Animator>().GetBool("Blocking");
        blockSlider.value = blockMeter;
        if(health <= 0)
        {
            GetComponent<EnemyBehaviorManager>().setActive(false);   
            blockSlider.transform.parent.gameObject.SetActive(false);
            if(GetComponent<LOSManager>().eque.combatants.Contains(GetComponent<EnemyBehaviorManager>().getEnemy()))
            {
                GetComponent<LOSManager>().eque.combatants.Remove(GetComponent<EnemyBehaviorManager>().getEnemy());
            }
        }
    }
    void FixedUpdate()
    {
        transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", false);
    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false && (blocking == false || blockMeter == 0))
        {
            health -= 1;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", true);
            Invul = true;
            StartCoroutine(InvulFrames());
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false && (blocking == false || blockMeter == 0))
        {
            health -= 1;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", true);
            Invul = true;
            StartCoroutine(InvulFrames());
        }
        else if (hurtbox.gameObject.tag == "Special Attack" && Invul == false)
        {
            health -= 1;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", true);
            Invul = true;
            StartCoroutine(InvulFrames());
        }
        else if((hurtbox.gameObject.tag == "Heavy Attack" || hurtbox.gameObject.tag == "Light Attack") && blocking && blockMeter != 0)
        {
            if(hurtbox.gameObject.tag == "Heavy Attack")
            {
                blockMeter -=2;
            }
            else
            {
                blockMeter--;
            }
            if(blockMeter == 0)
            {
                transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Stunned");
                Variables.Object(transform.gameObject).Set("Stunned", 2.5f);
            }
            hurtbox.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Blocked");
        }
    }
    public void setHealth(int h)
    {
        health = h;
    }
    public void setBlock(int b)
    {
        blockMax = b;
        blockMeter = b;
        blockSlider.maxValue = b;
    }
    IEnumerator InvulFrames()
    {
        if(health>0)
        {
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Takes Hit");
            Variables.Object(transform.gameObject).Set("Stunned", .2f);
        }
        yield return new WaitForSeconds(.25f);
        Invul = false;
    }
    IEnumerator BlockRegen()
    {
        yield return new WaitForSeconds(2);
        blockMeter = blockMax;
    }
}
