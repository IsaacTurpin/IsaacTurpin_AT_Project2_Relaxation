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

    public void Resume()
    {
        menu.SetActive(false);
        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }
        movingCube.GetComponent<Oscillator>().begin = true;
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
        movingCube.GetComponent<Oscillator>().begin = false;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
