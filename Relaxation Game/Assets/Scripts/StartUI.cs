using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartUI : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public static bool gameIsPaused = false;
    [SerializeField] GameObject player;
    [SerializeField] GameObject slider;
    [SerializeField] GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GameIsPaused()
    {
        return gameIsPaused;
    }

    public void Resume()
    {
        menu.SetActive(false);
        if (player != null)
        {
            player.GetComponent<Cloud>().enabled = true;
        }
        if (slider != null)
        {
            slider.SetActive(true);
        }
        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        menu.SetActive(true);
        if(player != null) 
        {
            player.GetComponent<Cloud>().enabled = false;
        }
        if (slider != null)
        {
            slider.SetActive(false);
        }
        if (pauseButton != null)
        {
            pauseButton.SetActive(false);
        }
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
