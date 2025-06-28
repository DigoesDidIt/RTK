using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    public Sprite FullHp;
    public Sprite FourHp;
    public Sprite ThreeHp;
    public Sprite TwoHp;
    public Sprite OneHp;
    public Sprite NoHp;
    private int hp;
    public HealthManager healthmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp = healthmanager.getHealth();
        switch(hp)
        {
            case 5:
                gameObject.GetComponent<Image>().sprite = FullHp;
                break;
            case 4:
                gameObject.GetComponent<Image>().sprite = FourHp;
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = ThreeHp;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = TwoHp;
                break;
            case 1:
                gameObject.GetComponent<Image>().sprite = OneHp;
                break;
            case 0:
                gameObject.GetComponent<Image>().sprite = NoHp;
                break;
        }
    }
}
