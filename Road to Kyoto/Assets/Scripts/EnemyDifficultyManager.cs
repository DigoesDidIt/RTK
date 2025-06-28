using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDifficultyManager : MonoBehaviour
{
    private int difficulty = 0;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject vars = GameObject.Find("Variables");
        if(vars != null)
        {
            difficulty = vars.GetComponent<VariableManager>().getDifficulty();
        }
        else
        {
            difficulty = 2;
            Debug.Log("Initiated scene without loading menu.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getDifficulty()
    {
        return difficulty;
    }
    public void setDifficulty(int i)
    {
        difficulty = i;
    }
}
