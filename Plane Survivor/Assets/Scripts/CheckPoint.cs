using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Animator myAnimator;
    GameSession gameSession;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameSession.Checkpoint();
            myAnimator.SetTrigger("Shine");
            StartCoroutine(destroy());
        }

    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy (gameObject);
    }
}