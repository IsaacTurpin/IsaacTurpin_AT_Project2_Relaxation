using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneController : MonoBehaviour
{
    [SerializeField] Scene currentScene;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject TransitionSpot1;
    [SerializeField] GameObject TransitionSpot2;
    [SerializeField] GameObject TransitionSpot3;
    [SerializeField] float distance;
    [SerializeField] float rangeLimit;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.buildIndex != 0)
        {
            //some sort of checkpoint, spawn back where you were in the hub. if scene is x spawn at x, pass into Cloud script Start function.
        }
    }

    private void Update()
    {
        
    }

    public void SceneSelector(int sceneIndex)
    {
        if(InRange(sceneIndex))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void OpenHubScene()
    {
        SceneManager.LoadScene(0);
    }

    public bool InRange(int sceneIndex)
    {
        Vector3 transitionSpot = Vector3.zero;
        switch (sceneIndex)
        {
            case 0:
                return false;
            case 1:
                transitionSpot = TransitionSpot1.transform.position;
                break;
            case 2:
                transitionSpot = TransitionSpot2.transform.position;
                break;
            case 3:
                transitionSpot = TransitionSpot3.transform.position;
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
