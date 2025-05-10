using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    private bool playerInside = false;
    private GameObject boundaries;
    public EnemyHealthManager bossHealthManager;
    public Slider bossHealthSlider;
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
        bool inBossFight = playerInside && bossHealthManager.getHealth() != 0;
        boundaries.SetActive(inBossFight);
        if(inBossFight && !bossHealthSlider.gameObject.activeSelf)
        {
            bossHealthSlider.gameObject.SetActive(true);
            bossHealthSlider.maxValue = bossHealthManager.getHealth();
            bossHealthSlider.value = bossHealthManager.getHealth();
        }
        else if(inBossFight)
        {
            bossHealthSlider.value = bossHealthManager.getHealth();
        }
        else if(inBossFight && !bossHealthSlider.gameObject.activeSelf)
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
        }
    }
}
