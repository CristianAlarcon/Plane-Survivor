using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inundator : MonoBehaviour {

	[SerializeField] float floodingSpeed = 0.01f;
	
	// Update is called once per frame
	void Update () {
        Vector2 newPos = gameObject.transform.position;
        newPos.y += floodingSpeed;
        gameObject.transform.position = newPos;		
	}
}
