using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
   /*Component[] components;
    Cinemachine.CinemachineBrain myCinema;
    Camera2DFollow myCamera;
    // Use this for initialization
    void Start()
    {
        components = GetComponents(typeof(Component));
        Debug.Log(components[0]);
        Debug.Log(components[1]);
        Debug.Log(components[2]);
        Debug.Log(components[3]);
        myCinema = GetComponent<Cinemachine.CinemachineBrain>();
        myCamera = GetComponent<Camera2DFollow>();
        myCamera.Enable(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myCinema.Enable(false);
            myCamera.Enable(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myCamera.Enable(false);
            myCinema.Enable(true);
        }
    }*/
}