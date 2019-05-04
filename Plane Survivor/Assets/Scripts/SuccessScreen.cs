using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessScreen : MonoBehaviour {

    [SerializeField] AudioClip victorySFX;
	// Use this for initialization
	void Start () {
        AudioSource.PlayClipAtPoint(victorySFX, Camera.main.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
