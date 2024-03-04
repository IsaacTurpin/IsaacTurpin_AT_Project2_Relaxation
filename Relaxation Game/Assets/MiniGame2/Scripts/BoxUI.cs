using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxUI : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public static bool gameIsPaused = false;

    [SerializeField] GameObject movingCube;

    public void Resume()
    {
        menu.SetActive(false);
        movingCube.GetComponent<Oscillator>().begin = true;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
