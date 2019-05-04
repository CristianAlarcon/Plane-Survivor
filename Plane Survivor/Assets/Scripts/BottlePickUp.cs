using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePickUp : MonoBehaviour {

    [SerializeField] AudioClip pickUpSFX;
    GameSession session;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            FindObjectOfType<GameSession>().IncreaseNumBottles();
            AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }

    }
}
