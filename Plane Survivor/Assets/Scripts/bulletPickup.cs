using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPickup : MonoBehaviour
{

    [SerializeField] AudioClip bulletSFX;
    GameSession session;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            FindObjectOfType<GameSession>().increaseNumBullets();
            AudioSource.PlayClipAtPoint(bulletSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }

    }
}