using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    public float health = 10;
    public AttackManager attackManager;
    public bool Invul;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Invul = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Damage()
    {

    }
    void OnTriggerEnter2D(Collider2D hurtbox) 
    {
        if(hurtbox.gameObject.tag == "Light Attack" && Invul == false)
        {
            health -= 1;
            Invul = true;
            animator.SetTrigger("Hit");
        }   
        else if(hurtbox.gameObject.tag == "Heavy Attack" && Invul == false)
        {
            health -= 1;
            Invul = true;
            animator.SetTrigger("HeavyHit");
        }
        else if (hurtbox.gameObject.tag == "Special Attack" && Invul == false)
        {
            health -= 1;
            Invul = true;
            animator.SetTrigger("HeavyHit");
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
