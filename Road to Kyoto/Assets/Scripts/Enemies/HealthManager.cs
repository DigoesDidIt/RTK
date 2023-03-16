using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(health <= 0)
        {
            return;
        }
    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false && blocking == false)
        {
            health -= attackManager.attackDecay;
            Invul = true;
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false && blocking == false)
        {
            health -= attackManager.attackDecay;
            Invul = true;
        } 
        
        StartCoroutine(InvulFrames());
        print("dummy" + hurtbox.gameObject.tag);
    }
    IEnumerator InvulFrames()
    {
        yield return new WaitForSeconds(.25f);
        Invul = false;
    }
}
