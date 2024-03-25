using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cinemachine;

public class SceneController : MonoBehaviour
{
    [SerializeField] Scene currentScene;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject TransitionSpot1;
    [SerializeField] GameObject TransitionSpot2;
    [SerializeField] GameObject TransitionSpot3;
    [SerializeField] float distance;
    [SerializeField] float rangeLimit;
    [SerializeField] GameObject backgroundMusic;

    [SerializeField] CinemachineVirtualCamera mainVCam;
    [SerializeField] CinemachineVirtualCamera startVCam;
    [SerializeField] CinemachineVirtualCamera vcam;
    [SerializeField] CinemachineVirtualCamera vcam2;
    [SerializeField] CinemachineVirtualCamera vcam3;
    [SerializeField] CinemachineVirtualCamera vcam4;

    //Start+info
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject infoStartMenu;
    [SerializeField] StartUI startUI;
    private static bool canInherit = true;


    //minigame2 transition
    [SerializeField] GameObject steeringCanvas;
    [SerializeField] GameObject speedCanvas;
    [SerializeField] GameObject miniGame2Canvas;
    [SerializeField] GameObject boxBreathing;

    //Minigame2 menu to info and back to menu
    [SerializeField] GameObject boxBreathingInfo;

    [SerializeField] GameObject starfield;

    //minigame3 transition
    [SerializeField] GameObject miniGame3Canvas;
    [SerializeField] GameObject soundBoardInfo;

    void Start()
    {
        startVCam.Priority = 11;
        canInherit = true;
    }

    private void InheritCloud()
    {
        CinemachineBrain cinemachineBrain = FindAnyObjectByType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 10;
        mainVCam.Priority = 11;
    }

    private void Update()
    {
        if(startUI != null) 
        {
            if(!startUI.GameIsPaused() && canInherit)
            {
                canInherit = false;
                Invoke("InheritCloud", 1f);

            }
        }
    }

    public void SceneSelector(int sceneIndex)
    {
        if(InRange(sceneIndex))
        {
            //switch case here, case1: SwitchCam() (minigame1) etc...
            switch (sceneIndex)
            {
                case 0:
                    return;
                case 1:
                    SwitchCamMiniGame3();
                    break;
                case 2:
                    SwitchCamMiniGame1();
                    break;
                case 3:
                    SwitchCamMiniGame2();
                    break;
            }
        }
    }

    private void SwitchCamMiniGame1()
    {
        Player.GetComponent<Cloud>().enabled = false;
        CinemachineBrain cinemachineBrain = FindAnyObjectByType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 10;
        vcam.Priority = 11;
        Invoke("BlastOff", 1.5f);
    }

    private void BlastOff()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.SetActive(false);
        }
        starfield.SetActive(true);
        CinemachineBrain cinemachineBrain = FindAnyObjectByType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 10;
        vcam2.Priority = 11;
        Invoke("LoadMiniGame1", 2.5f);
    }

    private void LoadMiniGame1()
    {
        SceneManager.LoadScene(2);
    }

    private void SwitchCamMiniGame2()
    {
        Player.GetComponent<Cloud>().enabled = false;
        steeringCanvas.SetActive(false);
        speedCanvas.SetActive(false);
        CinemachineBrain cinemachineBrain = FindAnyObjectByType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 10;
        vcam3.Priority = 11;
        boxBreathing.SetActive(true);
        Invoke("MiniGame2", 2f);

    }

    private void SwitchCamMiniGame3()
    {
        Player.GetComponent<Cloud>().enabled = false;
        steeringCanvas.SetActive(false);
        speedCanvas.SetActive(false);
        CinemachineBrain cinemachineBrain = FindAnyObjectByType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 10;
        vcam4.Priority = 11;
        Invoke("MiniGame3", 2f);
    }

    private void MiniGame2()
    {
        miniGame2Canvas.SetActive(true);
    }

    public void OpenInfoMG2()
    {
        miniGame2Canvas.SetActive(false);
        boxBreathingInfo.SetActive(true);
    }
    public void CloseInfoMG2()
    {
        miniGame2Canvas.SetActive(true);
        boxBreathingInfo.SetActive(false);
    }

    private void MiniGame3()
    {
        miniGame3Canvas.SetActive(true);
    }

    public void OpenInfoMG3()
    {
        miniGame3Canvas.SetActive(false);
        soundBoardInfo.SetActive(true);
    }
    public void CloseInfoMG3()
    {
        miniGame3Canvas.SetActive(true);
        soundBoardInfo.SetActive(false);
    }

    public void OpenInfoStart()
    {
        startMenu.SetActive(false);
        infoStartMenu.SetActive(true);
    }
    public void CloseInfoStart()
    {
        startMenu.SetActive(true);
        infoStartMenu.SetActive(false);
    }
    public void SwitchToMainCam()
    {
        if(miniGame2Canvas)
        {
            miniGame2Canvas.SetActive(false);
        }
        if(boxBreathing)
        {
            boxBreathing.GetComponentInChildren<Oscillator>().begin = false;
            boxBreathing.SetActive(false);
        }
        if (miniGame3Canvas)
        {
            miniGame3Canvas.SetActive(false);
        }
        CinemachineBrain cinemachineBrain = FindAnyObjectByType<CinemachineBrain>();
        cinemachineBrain.ActiveVirtualCamera.Priority = 10;
        mainVCam.Priority = 11;
        Player.GetComponent<Cloud>().enabled = true;
        steeringCanvas.SetActive(true);
        speedCanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OpenHubScene()
    {
        SceneManager.LoadScene(1);
    }

    public bool InRange(int sceneIndex)
    {
        Vector3 transitionSpot = Vector3.zero;
        switch (sceneIndex)
        {
            case 0:
                return false;
            case 1:
                transitionSpot = TransitionSpot3.transform.position;
                break;
            case 2:
                transitionSpot = TransitionSpot1.transform.position;
                break;
            case 3:
                transitionSpot = TransitionSpot2.transform.position;
                //transitionSpot = TransitionSpot3.transform.position; - add this if scene transition to mg3 to case 4.
                break;
        }
        distance = Vector3.Distance(Player.transform.position, transitionSpot);

        if(distance < rangeLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
