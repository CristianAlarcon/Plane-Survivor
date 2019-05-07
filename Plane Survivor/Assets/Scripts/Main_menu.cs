using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour {

    AudioSource audioSource;
    PlayerPrefs playerPrefs;


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
        audioSource = GetComponent<AudioSource>();
        playerPrefs = GameObject.Find("PlayerPrefs").GetComponent<PlayerPrefs>();
        audioSource.volume = playerPrefs.getVolume();
    }
	
	// Update is called once per frame
	void Update ()
    {
        audioSource.volume = playerPrefs.getVolume();
        if ((SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Start Menu")) && (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Options Menu")))
        {
            audioSource.Stop();
        }

    }


}
