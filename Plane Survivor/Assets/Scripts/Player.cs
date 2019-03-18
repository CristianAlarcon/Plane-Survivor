using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    bool CanJump = false;
    Collider2D myCollider;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float JumpForce = 5f;
    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Run();
        FlipSprite();
        Jump();
	}

    private void Run()
    {
        var controlHoritzontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 playerVelocity = new Vector2(controlHoritzontal * moveSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool hihaMovimentHoritzontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", hihaMovimentHoritzontal);
    }

    private void Jump()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 JumpVelocity = new Vector2(0f, JumpForce);
            myRigidBody.velocity = JumpVelocity;
        }
    }

    private void FlipSprite()
    {
        bool hihaMovimentHoritzontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; //epsilon és el float més petit, perquè si comparem amb 0 pot donar error
        if (hihaMovimentHoritzontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x) * 1.25f, 1.25f); //1.25 perquè és l'escala del nostre personatge, el sign ens indica si esquerra o dreta
        }
    }

}
