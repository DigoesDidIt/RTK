using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyButtonManager : MonoBehaviour
{
    public VariableManager varManager;
    public int dif = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Button); 
        dif = 1;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Normal";
        varManager.setDifficulty(dif);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button()
    {
        if(dif == 1)
        {
            dif = 2;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Veteran";
            varManager.setDifficulty(dif);
        }
        else
        {
            dif = 1;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Normal";
            varManager.setDifficulty(dif);
        }
    }

}
