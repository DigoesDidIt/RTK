using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class DeathMenuManager : MonoBehaviour
{
    public Button dead;
    public HealthManager healthManager;
    public Light2D globalLight;
    // Start is called before the first frame update
    void Start()
    {
        dead.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthManager.getHealth() <= 0)
        {
            dead.gameObject.SetActive(true);
            globalLight.intensity = globalLight.intensity *.99f;
            if(Input.GetKeyUp("r"))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
