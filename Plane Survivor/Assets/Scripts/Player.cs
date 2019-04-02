using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    bool CanJump = false;
    bool isAlive = true;
    bool facingRight = true;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float JumpForce = 5f;
    [SerializeField] Vector2 mortalHit = new Vector2(10f,8f);
    [SerializeField] float DieSlowMotionFactor = 0.4f;

    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        Jump();
        Die();
	}

    private void Run()
    {
        /*if (Input.GetKey("left"))
        {
            var controlHoritzontal = Input.GetAxis("Horizontal") * Time.deltaTime;
            Vector2 playerVelocity = new Vector2(controlHoritzontal * moveSpeed, myRigidBody.velocity.y);
            myRigidBody.velocity = playerVelocity;
            facingRight = false;
            myAnimator.SetBool("Running", true);
        }
        else if (Input.GetKey("right"))
        {
            myRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, myRigidBody.velocity.y);
            facingRight = true;
            myAnimator.SetBool("Running", true);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
        */
        var controlHoritzontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 playerVelocity = new Vector2(controlHoritzontal * moveSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool hihaMovimentHoritzontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (hihaMovimentHoritzontal)
        {
            facingRight = Input.GetAxis("Horizontal") > Mathf.Epsilon;
        }
        myAnimator.SetBool("Facing Right", facingRight);
        if (facingRight)
        {
            myAnimator.SetBool("Running Right", hihaMovimentHoritzontal);
        }
        else
        {
            myAnimator.SetBool("Running Left", hihaMovimentHoritzontal);
        }
    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetBool("Jump1", true);
        }
        else
        {
            myAnimator.SetBool("Jump1", false);
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 JumpVelocity = new Vector2(0f, JumpForce);
                myRigidBody.velocity = JumpVelocity;
            }
        }
    }

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Foreground", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidBody.velocity = mortalHit;
            StartCoroutine(ErasePlayer());
        }
    }

    IEnumerator ErasePlayer()
    {
        Time.timeScale = DieSlowMotionFactor;
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    private void FlipSprite()
    {
        bool hihaMovimentHoritzontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; //epsilon és el float més petit, perquè si comparem amb 0 pot donar error
        if (hihaMovimentHoritzontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x) * 1f, 1f); //1.25 perquè és l'escala del nostre personatge, el sign ens indica si esquerra o dreta
        }
    }

}
