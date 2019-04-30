using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inundator : MonoBehaviour
{

    [SerializeField]
    float floodingSpeed = 0.01f;
    Vector2 initialPosition;
    PauseMenu pauseScript;

    void Start()
    {
        initialPosition = gameObject.transform.position;
        pauseScript = GameObject.FindGameObjectWithTag("PauseObjects").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseScript.isPaused()) 
        {
            Vector2 newPos = gameObject.transform.position;
            newPos.y += floodingSpeed;
            gameObject.transform.position = newPos;
        }
    }

    public void DoubleSpeed()
    {
        floodingSpeed *= 1.7f;
    }

    public void ReduceSpeed()
    {
        floodingSpeed /= 1.7f;
    }


    public void RestartPosition()
    {
        gameObject.transform.position = initialPosition;
    }
}
