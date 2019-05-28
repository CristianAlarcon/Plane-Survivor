using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Movement : MonoBehaviour {

    protected bool isAlive = true;
    Animator myAnimator;
    [SerializeField]
    AudioClip hitSFX;
    [SerializeField]
    float moveSpeed = 2.5f;
    Rigidbody2D myRigidBody;
    BoxCollider2D myFeet;
    CircleCollider2D myCollider;


    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!getHealth())
        {
            moveSpeed = 0;
        }

        if (isFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }

    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            transform.localScale = new Vector2(Mathf.Sign(-myRigidBody.velocity.x), 1f);
        }

    }

    public void die()
    {
        isNotAlive();
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);
        StartCoroutine(ErasePlayerandLoad());
    }

    IEnumerator ErasePlayerandLoad()
    {
        myAnimator.SetTrigger("Death");
        Destroy(myFeet);
        Destroy(myCollider);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void isNotAlive()
    {
        isAlive = false;
    }

    private bool getHealth()
    {
        return isAlive;
    }
}