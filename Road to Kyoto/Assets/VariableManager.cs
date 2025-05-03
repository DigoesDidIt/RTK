using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    private static int difficulty;
    // Start is called before the first frame update
    void Awake()
    {
        int numVars = FindObjectsOfType<VariableManager>().Length;
        if (numVars != 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
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
