using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed = 10f;
    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetAxis("Horizontal")!= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Running", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Running", false);
        }
        Run();
        FlipSprite();
	}

    private void Run()
    {
        var controlHoritzontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 playerVelocity = new Vector2(controlHoritzontal * moveSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
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
