using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TouchController touchController;
    [SerializeField] GameObject backgroundMusic;
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if(pauseMenu != null) 
        {
            pauseMenu.SetActive(false);
        }
        if (backgroundMusic != null)
        {
            backgroundMusic.SetActive(false);
        }

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        if(touchController != null)
        {
            touchController.enabled = true;
        }
        if(backgroundMusic != null) 
        {
            backgroundMusic.SetActive(true);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        if(touchController != null)
        {
            touchController.enabled = false;
        }
        if (backgroundMusic != null)
        {
            backgroundMusic.SetActive(false);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpenHubScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
