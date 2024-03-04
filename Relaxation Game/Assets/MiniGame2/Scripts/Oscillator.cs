using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    //[SerializeField] [Range(0,1)] float movementFactor; - how to make something a slider in inspector
    float movementFactor;
    [SerializeField] float period = 2f;
    public bool begin;
    private bool goLeft;
    private bool goRight;
    private bool goUp;
    private bool goDown;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
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

            if (transform.localPosition.x <= movementVector.x)
            {
                goLeft = false;
                goDown = true;
            }
        }

        if (goDown)
        {
            transform.Translate(Vector3.down * period * Time.deltaTime);

            if (transform.localPosition.y <= movementVector.y)
            {
                goDown = false;
                goRight = true;
            }
        }

        if (goRight)
        {
            transform.Translate(Vector3.right * period * Time.deltaTime);

            if (transform.localPosition.x >= startingPosition.x + 0.204)
            {
                goRight = false;
                goUp = true;
            }
        }

        if (goUp)
        {
            transform.Translate(Vector3.up * period * Time.deltaTime);

            if (transform.localPosition.y >= startingPosition.y)
            {
                goUp = false;
                goLeft = true;
            }
        }
    }

    void old()
    {



        if (period <= Mathf.Epsilon) return; // Epsilon is a tiny number - the smallest possible float above 0

        float cycles = Time.time / period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner

        Vector3 offset = movementVector * movementFactor;
        transform.localPosition = startingPosition + offset;
    }
}
