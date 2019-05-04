using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    GameObject[] pauseObjects;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("Pause");
        hideMenu();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                enableMenu();
            }
            else if (Time.timeScale == 0)
            {
                continueGame();
            }
        }
	}

    public void enableMenu()
    {
        foreach(GameObject p in pauseObjects)
        {
            p.SetActive(true);
        }
    }

    public void hideMenu()
    {
        foreach (GameObject p in pauseObjects)
        {
            p.SetActive(false);
        }
    }


     public void continueGame()
    {
        Time.timeScale = 1;
        hideMenu();
    }
}
