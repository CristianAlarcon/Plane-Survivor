using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;
    PlayerPrefs playerPrefs;
    
    /*private void Awake()
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
    }*/
    // Use this for initialization
    void Start ()
    {
        playerPrefs = GameObject.Find("PlayerPrefs").GetComponent<PlayerPrefs>();
        volumeSlider.value = playerPrefs.getVolume();
        difficultySlider.value = playerPrefs.getDifficulty();
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerPrefs.setVolume(volumeSlider.value);
        playerPrefs.setDifficulty(difficultySlider.value);
    }

    public void setDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
    
}
