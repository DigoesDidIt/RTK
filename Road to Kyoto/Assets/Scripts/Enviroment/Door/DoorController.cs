using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public BoxCollider2D collider;
    public PlayerMovement playerMovement;
    public Animator playerAnimator;
    bool isOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        collider.offset = new Vector2(1.36f,0f);
        collider.size = new Vector2(0.25f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player" && isOpen == false)
        {
            collider.offset = new Vector2(1.36f,1f);
            collider.size = new Vector2(0.25f,1f);
            isOpen = true;
            playerAnimator.SetTrigger("OpenDoor");
            StartCoroutine(DoorDelay());
        }
    }
        IEnumerator DoorDelay()
        {
            playerMovement.canMove = false;
            yield return new WaitForSeconds(.2f);
            playerMovement.canMove = true;
        }
}
