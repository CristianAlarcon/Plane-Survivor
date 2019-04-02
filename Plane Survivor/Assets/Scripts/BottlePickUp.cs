using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePickUp : MonoBehaviour {

    //[SerializeField] AudioClip pickUpSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
