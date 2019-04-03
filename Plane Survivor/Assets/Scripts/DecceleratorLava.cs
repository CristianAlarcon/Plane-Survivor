using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecceleratorLava : MonoBehaviour {

    Inundator inundator;

    void Start()
    {
        GameObject Lava = GameObject.Find("Lava");
        inundator = Lava.GetComponent<Inundator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inundator.ReduceSpeed();
        }
    }
}
