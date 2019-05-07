using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inundator : MonoBehaviour
{

    [SerializeField]
    float floodingSpeed = 0.01f;
    Vector2 initialPosition;
    bool descending;
    PlayerPrefs playerPrefs;

    void Start()
    {
        playerPrefs = GameObject.Find("PlayerPrefs").GetComponent<PlayerPrefs>();
        if (playerPrefs.getDifficulty() == 1f)
        {
            floodingSpeed = 0.009f;
        }
        else if (playerPrefs.getDifficulty() == 0f)
        {
            floodingSpeed = 0.0085f;
        }
        initialPosition = gameObject.transform.position;
        descending = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        else
        {
            if (descending)
            {
                Vector2 newPos = gameObject.transform.position;
                newPos.y -= floodingSpeed;
                gameObject.transform.position = newPos;
            }
            else
            {
                Vector2 newPos = gameObject.transform.position;
                newPos.y += floodingSpeed;
                gameObject.transform.position = newPos;
            }
        }
    }

    public void DoubleSpeed()
    {
        floodingSpeed = 0.017f;
    }

    public void ReduceSpeed()
    {
        floodingSpeed = 0.007f;
    }

    public void LavaDown()
    {
        StartCoroutine(DescentLava());
    }

    IEnumerator DescentLava()
    {
        descending = true;
        floodingSpeed = 0.08f;
        yield return new WaitForSeconds(2f);
        descending = false;
        floodingSpeed = 0.01f;
    }
    public void RestartPosition()
    {
        gameObject.transform.position = initialPosition;
    }
}
