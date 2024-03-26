using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    public bool begin;
    private bool goLeft;
    private bool goRight;
    private bool goUp;
    private bool goDown;

    [SerializeField] AudioSource audioSource;

    //World space text
    [SerializeField] GameObject breatheInText;
    [SerializeField] GameObject hold1Text;
    [SerializeField] GameObject breatheOutText;
    [SerializeField] GameObject hold2Text;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(begin)
        {
            Movement();
        }
        if(!begin)
        {
            goLeft = false;
            goRight = false;
            goDown = false;
            goUp = false;
            breatheInText.SetActive(false);
            hold1Text.SetActive(false);
            breatheOutText.SetActive(false);
            hold2Text.SetActive(false);
            transform.localPosition = startingPosition;
        }
        
    }

    void Movement()
    {
        if(!goDown && !goRight && !goUp)
        {
            goLeft = true;
        }

        if (goLeft)
        {
            transform.Translate(Vector3.left * period * Time.deltaTime);
            breatheInText.SetActive(true);
            hold1Text.SetActive(false);
            breatheOutText.SetActive(false);
            hold2Text.SetActive(false);

            if (transform.localPosition.x <= movementVector.x)
            {
                audioSource.Play();
                goLeft = false;
                goDown = true;
            }
        }

        if (goDown)
        {
            transform.Translate(Vector3.down * period * Time.deltaTime);
            breatheInText.SetActive(false);
            hold1Text.SetActive(true);
            breatheOutText.SetActive(false);
            hold2Text.SetActive(false);

            if (transform.localPosition.y <= movementVector.y)
            {
                audioSource.Play();
                goDown = false;
                goRight = true;
            }
        }

        if (goRight)
        {
            transform.Translate(Vector3.right * period * Time.deltaTime);
            breatheInText.SetActive(false);
            hold1Text.SetActive(false);
            breatheOutText.SetActive(true);
            hold2Text.SetActive(false);

            if (transform.localPosition.x >= startingPosition.x + 0.204)
            {
                audioSource.Play();
                goRight = false;
                goUp = true;
            }
        }

        if (goUp)
        {
            transform.Translate(Vector3.up * period * Time.deltaTime);
            breatheInText.SetActive(false);
            hold1Text.SetActive(false);
            breatheOutText.SetActive(false);
            hold2Text.SetActive(true);

            if (transform.localPosition.y >= startingPosition.y)
            {
                audioSource.Play();
                goUp = false;
                goLeft = true;
            }
        }
    }
}
