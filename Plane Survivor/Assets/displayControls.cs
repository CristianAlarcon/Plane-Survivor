using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayControls : MonoBehaviour {

    GameObject arrow;
    GameObject ctrl;
    GameObject space;

	// Use this for initialization
	void Start () {
        arrow = GameObject.Find("Arrow");
        ctrl = GameObject.Find("Ctrl");
        space = GameObject.Find("Space");
        ctrl.SetActive(false);
        space.SetActive(false);
        StartCoroutine(showControls());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator showControls()
    {
        yield return new WaitForSeconds(3.8f);
        arrow.SetActive(false);
        ctrl.SetActive(true);
        yield return new WaitForSeconds(3.8f);
        ctrl.SetActive(false);
        space.SetActive(true);
        yield return new WaitForSeconds(3.8f);
        space.SetActive(false);
        yield return new WaitForSeconds(3.8f);
        arrow.SetActive(true);
        StartCoroutine(showControls());
    }
}
