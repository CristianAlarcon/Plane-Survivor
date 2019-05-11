using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour{
/*
    public float dampTime = 0.5f;
    public Transform target;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target)
        {
            if (target.GetComponent<Rigidbody2D>().velocity.x < -3 || target.GetComponent<Rigidbody2D>().velocity.x > 3)
            {
                Vector3 aheadPoint = target.position + new Vector3(target.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                Vector3 point = Camera.main.WorldToViewportPoint(aheadPoint);
                Vector3 delta = aheadPoint - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }

        }
    }*/
}