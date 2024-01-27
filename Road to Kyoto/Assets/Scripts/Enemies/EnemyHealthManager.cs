using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;
//[IncludeInSettings(true)];
public class EnemyHealthManager : MonoBehaviour
{
    public float health;
    private bool Invul;
    public bool blocking;

    public int blockMeter;
    // Start is called before the first frame update
    void Start()
    {
        blockMeter = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Variables.Object(gameObject).Set("Health", health);
        blocking = transform.GetChild(0).GetComponent<Animator>().GetBool("Blocking");;
    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false && (blocking == false || blockMeter == 0))
        {
            health -= 1;
            Invul = true;
            StartCoroutine(InvulFrames());
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false && (blocking == false || blockMeter == 0))
        {
            health -= 1;
            Invul = true;
            StartCoroutine(InvulFrames());
        }
        else if (hurtbox.gameObject.tag == "Special Attack" && Invul == false)
        {
            health -= 1;
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
    IEnumerator InvulFrames()
    {
        yield return new WaitForSeconds(.25f);
        Invul = false;
    }
    IEnumerator BlockRegen()
    {
        yield return new WaitForSeconds(2);
        blockMeter = 4;
    }
}
