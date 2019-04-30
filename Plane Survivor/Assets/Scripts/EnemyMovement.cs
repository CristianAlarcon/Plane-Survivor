using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected bool isAlive= true;
    Animator myAnimator;
    [SerializeField]
    float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    BoxCollider2D myFeet;
    CapsuleCollider2D myCollider;


    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!getHealth())
        {
            moveSpeed = 0;
        }

        if (isFacingLeft())
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }

    }

    bool isFacingLeft()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }

    }

    public void die()
    {
        //myAnimator.SetTrigger("Death");
        isNotAlive();
        
        StartCoroutine(ErasePlayerandLoad());
    }

    IEnumerator ErasePlayerandLoad()
    {
        myAnimator.SetTrigger("Death");
        Destroy(myFeet);
        Destroy(myCollider);
        yield return new WaitForSeconds(1.5f);
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