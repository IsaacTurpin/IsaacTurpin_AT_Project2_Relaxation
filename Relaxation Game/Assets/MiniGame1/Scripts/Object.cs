using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour
{
    [SerializeField] int scoreChange;
    ScoreController scoreController;
    private void Start()
    {
        scoreController = GameObject.FindWithTag("GameController").GetComponent<ScoreController>();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void ObjectHit(ObjectType objectType)
    {
        switch (objectType)
        {
            case ObjectType.Good:
                scoreController.IncreaseScore(scoreChange);
                Debug.Log("Score Increase");
                Destroy(gameObject);
                break;

            case ObjectType.Bad:
                scoreController.DecreaseScore(scoreChange);
                Debug.Log("Score Decrease");
                Destroy(gameObject);
                break;
        }
    }
}
