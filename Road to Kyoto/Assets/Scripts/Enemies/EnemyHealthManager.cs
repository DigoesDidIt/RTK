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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Variables.Object(gameObject).Set("Health", health);
        blocking = transform.GetChild(0).GetComponent<Animator>().GetBool("Blocking");;
    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false && blocking == false)
        {
            health -= 1;
            Invul = true;
            StartCoroutine(InvulFrames());
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false && blocking == false)
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
        else if((hurtbox.gameObject.tag == "Heavy Attack" || hurtbox.gameObject.tag == "Light Attack") && blocking)
        {
            hurtbox.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Blocked");
        }
    }
    IEnumerator InvulFrames()
    {
        yield return new WaitForSeconds(.25f);
        Invul = false;
    }
}
