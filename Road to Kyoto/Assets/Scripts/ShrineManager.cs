using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ShrineManager : MonoBehaviour
{
    public int healing = 1;
    private bool visited;
    public ParticleSystem particleSystem;
    public Light2D light;
    private Animator playerAnimator;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        visited = false;
        light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && visited == false)
        {
            visited = true;
            collider.gameObject.GetComponent<HealthManager>().changeHealth(healing);
            playerAnimator.SetTrigger("OpenDoor");
            StartCoroutine(ShrineDelay());
        }
    }
        IEnumerator ShrineDelay()
    {
        playerMovement.canMove = false;
        yield return new WaitForSeconds(.2f);
        particleSystem.Play();
        light.intensity = 1;
        playerMovement.canMove = true;
    }
}
