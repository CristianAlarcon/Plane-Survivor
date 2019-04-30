using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 3;
    int numBottles = 0;
    [SerializeField] int bullets = 3;
    private int health;
    [SerializeField] Slider HealthBar;
    [SerializeField] int numberOfHits = 3;
    [SerializeField] Text livesText;
    [SerializeField] Text bottlesText;


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
    void Start () {
        livesText.text = (playerLives-1).ToString();
        bottlesText.text = numBottles.ToString();
        health = numberOfHits;
        HealthBar.value = getHealth();
    }

    void Update()
    {

    }
    // Update is called once per frame

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        resetHealth();
        HealthBar.value = getHealth();
        livesText.text = (playerLives-1).ToString();
    }
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        Time.timeScale = 1;
    }

    public void IncreaseNumBottles()
    {
        numBottles++;
        bottlesText.text = numBottles.ToString();
    }

    public void takeHit()
    {
        health--;
        Debug.Log("Health: " + getHealth());
        HealthBar.value = getHealth();
    }

    public int getHealth()
    {
        return health;
    }

    public void resetHealth()
    {
        health = numberOfHits;
    }
}
