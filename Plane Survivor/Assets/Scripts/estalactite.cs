using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estalactite : MonoBehaviour {

    PolygonCollider2D myCollider;
    Animator myAnimator;
    ParticleSystem.EmissionModule em;

    // Use this for initialization
    void Start () {
        myCollider = gameObject.GetComponent<PolygonCollider2D>();
        myAnimator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        disappear();
    }

    public void disappear()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetTrigger("disappear");
            StartCoroutine(delayDestroy());
        }
    }

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.65f);
        Destroy(gameObject);
    }

}
