using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class HealthManager : MonoBehaviour
{
    public float health;
    public AttackManager attackManager;
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
    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false && blocking == false)
        {
            health -= 1;
            Invul = true;
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false && blocking == false)
        {
            health -= 1;
            Invul = true;
        }
        else if (hurtbox.gameObject.tag == "Special Attack" && Invul == false)
        {
            health -= 1;
            Invul = true;
        }

        StartCoroutine(InvulFrames());
    }
    IEnumerator InvulFrames()
    {
        yield return new WaitForSeconds(.25f);
        Invul = false;
    }
}
