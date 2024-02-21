using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TouchController touchController;
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        if(touchController != null)
        {
            touchController.enabled = true;
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
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpenHubScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
