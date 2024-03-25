using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxUI : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public static bool gameIsPaused = false;

    [SerializeField] GameObject movingCube;
    [SerializeField] GameObject pauseButton;

    [SerializeField] GameObject miniGame3;

    public void Resume()
    {
        menu.SetActive(false);
        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }
        if (movingCube != null) 
        {
            movingCube.GetComponent<Oscillator>().begin = true;
        }
        if(miniGame3 != null)
        {
            miniGame3.SetActive(true);
        }
        
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        menu.SetActive(true);
        if (pauseButton != null)
        {
            pauseButton.SetActive(false);
        }
        if(movingCube != null)
        {
            movingCube.GetComponent<Oscillator>().begin = false;
        }
        if (miniGame3 != null)
        {
            miniGame3.SetActive(false);
        }

        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
