using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour {

    float difficulty;
    float volume;
    float volumeFX;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        volume = 0.5f;
        volumeFX = 0.5f;
        difficulty = 0f;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setVolume(float number)
    {
        volume = number;
    }

    public float getVolume()
    {
        return volume;
    }

    public void setDifficulty(float number)
    {
        difficulty = number;
    }

    public float getDifficulty()
    {
        return difficulty;
    }

    public void setVolumeFX(float number)
    {
        volumeFX = number;
    }

    public float getVolumeFX()
    {
        return volumeFX;
    }
}
