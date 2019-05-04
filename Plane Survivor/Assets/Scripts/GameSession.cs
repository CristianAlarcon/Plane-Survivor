using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] int playerLives = 3;
    int numBottles = 0;
    [SerializeField] int bullets = 3;
    private int health;
    [SerializeField] Slider HealthBar;
    [SerializeField] int numberOfHits = 3;
    [SerializeField] Text livesText;
    [SerializeField] Text bottlesText;
    [SerializeField] GameObject Warning;
    [SerializeField] GameObject Initial;
    [SerializeField] GameObject GameOverObject;
    GameObject persistent;
    Scene currentScene;


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
        livesText.text = (playerLives).ToString();
        bottlesText.text = numBottles.ToString();
        health = numberOfHits;
        HealthBar.value = getHealth();
        Warning.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        GameOverObject.SetActive(false);
        StartCoroutine(disableMessage(Initial));
        persistent = GameObject.Find("ScenePersist");
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
            //returnMainMenuSession();
            GameOverSession();
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
        Time.timeScale = 1;
    }

    public void GameOverSession()
    {
        Time.timeScale = 0;
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position); 
        GameOverObject.SetActive(true);
    }

    public void Victory()
    {
        audioSource.Stop();
    }

    public void startAgain()
    {
        SceneManager.LoadScene(1);
        Destroy(persistent);
        Destroy(gameObject);
    }

    public void returnMainMenuSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        Time.timeScale = 1;
        audioSource.Stop();
    }

    public void IncreaseNumBottles()
    {
        numBottles++;
        bottlesText.text = numBottles.ToString();
    }

    public void takeHit()
    {
        health--;
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

    public bool enoughBottles()
    {
        if (numBottles > 4)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public void showWarning()
    {
        Warning.SetActive(true);
        StartCoroutine(disableMessage(Warning));
    }

    IEnumerator disableMessage(GameObject name)
    {
        yield return new WaitForSeconds(2f);
        name.SetActive(false);
    }
}
