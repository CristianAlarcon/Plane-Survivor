using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inundator : MonoBehaviour
{

    [SerializeField]
    float floodingSpeed = 0.01f;
    CompositeCollider2D Lava;
    Vector2 initialPosition;

    void Start()
    {
        Lava = GetComponent<CompositeCollider2D>();
        initialPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = gameObject.transform.position;
        newPos.y += floodingSpeed;
        gameObject.transform.position = newPos;
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
