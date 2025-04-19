using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    public bool paused = false;
    public Button resume;
    public Button quit;
    public Button menu
        ;
    public Light2D globalLight;
    public PlayerMovement playerMovement;
    public AttackManager attackManager;
    private bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        resume.onClick.AddListener(Resume);
        quit.onClick.AddListener(Application.Quit);
        menu.onClick.AddListener(Menu);
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            paused = !paused;
            if (paused)
            {
                resume.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
                globalLight.intensity = globalLight.intensity / 2;
                Time.timeScale = 0;
                move = playerMovement.canMove;
                playerMovement.canMove = false;
                attackManager.canAttack = false;

            }
            else
            {
                Resume();
            }
        } 
    }
    void Resume()
    {
        paused = false;
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        globalLight.intensity = globalLight.intensity * 2;
        Time.timeScale = 1;
        playerMovement.canMove = move;
        attackManager.canAttack = true;
    }
    void Menu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

}
