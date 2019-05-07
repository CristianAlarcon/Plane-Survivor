using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteFall : MonoBehaviour
{
    Rigidbody2D rigid;
    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponentInChildren<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }   
    }
}
