using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    private bool playerInside = false;
    private GameObject boundaries;
    public EnemyHealthManager bossHealthManager;
    public LOSManager bossLosManager;
    public Slider bossHealthSlider;
    private bool cleared = false;
    // Start is called before the first frame update
    void Start()
    {
        boundaries = transform.Find("Boundaries").gameObject;
        bossHealthSlider = GameObject.Find("Canvas/BossHealth").gameObject.GetComponent<Slider>();
        bossHealthSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool bossAlive = bossHealthManager.getHealth() != 0;
        bool inBossFight = playerInside && bossAlive;
        boundaries.SetActive(inBossFight);
        if(inBossFight && !bossHealthSlider.gameObject.activeSelf)
        {
            bossLosManager.ForceAgro();
            bossHealthSlider.gameObject.SetActive(true);
            bossHealthSlider.maxValue = bossHealthManager.getHealth();
            bossHealthSlider.value = bossHealthManager.getHealth();
        }
        else if(inBossFight)
        {
            bossHealthSlider.value = bossHealthManager.getHealth();
        }
        else if(playerInside && !cleared)
        {
            bossHealthSlider.value = bossHealthManager.getHealth();
        }
        else 
        {
            bossHealthSlider.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInside = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInside = false;
            if(bossHealthManager.getHealth() == 0)
            {
                cleared = true;
            }
        }
    }
}
