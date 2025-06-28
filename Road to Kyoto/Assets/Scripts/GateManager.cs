using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;


public class GateManager : MonoBehaviour
{
    private List<string> gates = new List<string>() {"Gate1", "Gate2", "Gate3"};
    // Start is called before the first frame update
    void Start()
    {
        SpriteResolver spriteResolver = GetComponent<SpriteResolver>();
        spriteResolver.SetCategoryAndLabel("Gate", gates[Random.Range(0,3)]);
        spriteResolver.ResolveSpriteToSpriteRenderer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
