using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class EnemySpriteManager : MonoBehaviour
{
    public SpriteResolver helmets;
    public SpriteResolver leftArms;
    public SpriteResolver rightArms;
    public SpriteResolver chestplates;
    public SpriteResolver legArmors;
    private List<string> ranks = new List<string>() {"Novice", "Adept", "Expert", "Master"};
    private int rank;


    // Start is called before the first frame update
    void Start()
    {
        rank = GetComponent<EnemyBehaviorManager>().tier;
        helmets.SetCategoryAndLabel("Helmets", ranks[rank-1]);
        helmets.ResolveSpriteToSpriteRenderer();
        leftArms.SetCategoryAndLabel("Left Arm", ranks[Random.Range(0,rank)]);
        leftArms.ResolveSpriteToSpriteRenderer();
        rightArms.SetCategoryAndLabel("Right Arm", ranks[Random.Range(0,rank)]);
        rightArms.ResolveSpriteToSpriteRenderer();
        chestplates.SetCategoryAndLabel("Body - Upper", ranks[Random.Range(0,rank)]);
        chestplates.ResolveSpriteToSpriteRenderer();
        legArmors.SetCategoryAndLabel("Body - Lower", ranks[Random.Range(0,rank)]);
        legArmors.ResolveSpriteToSpriteRenderer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
