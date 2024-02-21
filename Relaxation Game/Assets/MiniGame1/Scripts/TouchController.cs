using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchController : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Ray ray = mainCamera.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ally")
                {
                    hit.rigidbody.GetComponent<Object>().ObjectHit(ObjectType.Good);
                }

                if (hit.transform.tag == "Enemy")
                {
                    hit.rigidbody.GetComponent<Object>().ObjectHit(ObjectType.Bad);
                }
            }
        }
    }
}

