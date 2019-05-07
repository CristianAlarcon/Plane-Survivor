using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour
{
    protected bool isAlive = true;
    Animator myAnimator;
    [SerializeField]
    float moveSpeed = 1f;
    bool isUpwards;
    bool isDownwards;
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myCollider;


    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!getHealth())
        {
            moveSpeed = 0;
        }

        /*if (isUpwards())
        {
            myRigidBody.velocity = new Vector2(0f, -moveSpeed);
        }
        else if (isDownwards)
        {
            myRigidBody.velocity = new Vector2(0f,moveSpeed);
        }*/

    }


    public void die()
    {
        isNotAlive();

        StartCoroutine(ErasePlayerandLoad());
    }

    IEnumerator ErasePlayerandLoad()
    {
        myAnimator.SetTrigger("Death");
        //Destroy(myFeet);
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