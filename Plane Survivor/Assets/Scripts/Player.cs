using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    [SerializeField] GameObject projectile;
    bool CanShoot = true;
    bool canBeHit = true;
    bool isAlive = true;
    bool timeToDie = false;
    bool facingRight = true;
    CapsuleCollider2D myBodyCollider;
    SpriteRenderer myRenderer;
    GameSession game;
    BoxCollider2D myFeet;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float JumpForce = 8f;
    [SerializeField] Vector2 mortalHit = new Vector2(10f,8f);
    [SerializeField] float DieSlowMotionFactor = 0.5f;

    // Use this for initialization
    void Start ()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex!= 0)
        {
            game = GameObject.Find("GameSession").GetComponent<GameSession>();
        }
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        Jump();
        Hit();
        Die();
        Shoot();
	}

    private void Run()
    {
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

    private void Hit()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")) && canBeHit)
        {
            game.takeHit();
            if (game.getHealth() <= 0)
            {
                Debug.Log("Dead");
                timeToDie = true;
            }
            else
            {
                canBeHit = false;
                StartCoroutine(HitTime());
            }
        }
    }

    IEnumerator HitTime()
    {
        myAnimator.SetTrigger("Hit");
        myRigidBody.velocity = mortalHit*2;
        for (var number = 0; number < 15; number++)
        {
            myRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            myRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
        myRenderer.enabled = true;
        canBeHit = true;
    }

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Foreground")) || timeToDie)
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidBody.velocity = mortalHit;
            StartCoroutine(ErasePlayerandLoad());
        }
    }

    IEnumerator ErasePlayerandLoad()
    {
        Time.timeScale = DieSlowMotionFactor;
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    IEnumerator NotmovingInShoot()
    {
        myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(0.2f);
        myRigidBody.constraints = RigidbodyConstraints2D.None;
        transform.rotation = new Quaternion(0.0f,0.0f, 0.0f, 0.0f); 
        myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator DelayNextShoot()
    {
        CanShoot = false;
        yield return new WaitForSeconds(1f);
        CanShoot = true;
    }

    private void FlipSprite()
    {
        bool hihaMovimentHoritzontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; //epsilon és el float més petit, perquè si comparem amb 0 pot donar error
        if (hihaMovimentHoritzontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x) * 1f, 1f); //1.25 perquè és l'escala del nostre personatge, el sign ens indica si esquerra o dreta
        }
    }

    private void Shoot()
    {

        if (Input.GetButtonDown("Fire1") && CanShoot)
        {
            if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myAnimator.SetBool("Shoot", true);
                GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                StartCoroutine(NotmovingInShoot());
                StartCoroutine(DelayNextShoot());
            }
        }
        else
        {
            myAnimator.SetBool("Shoot", false);
        }
    }

    public bool isFacingRight()
    {
        return facingRight;
    }

}
