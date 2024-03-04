using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartUI : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public static bool gameIsPaused = false;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        menu.SetActive(false);
        if (player != null)
        {
            player.GetComponent<Cloud>().enabled = true;
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
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
