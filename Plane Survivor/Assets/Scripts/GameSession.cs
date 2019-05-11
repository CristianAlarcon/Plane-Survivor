using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] float playerLives = 3;
    int numBottles = 0;
    bool checkpoint = false;
    [SerializeField] float bullets = 5;
    private float health;
    [SerializeField] Slider HealthBar;
    [SerializeField] float numberOfHits = 3;
    [SerializeField] Text livesText;
    [SerializeField] Text bottlesText;
    [SerializeField] Text bottlesText2;
    [SerializeField] GameObject TextBottles;
    [SerializeField] GameObject Warning;
    [SerializeField] GameObject Initial;
    [SerializeField] GameObject upperObjects;
    [SerializeField] Text bulletsText;
    [SerializeField] GameObject GameOverObject;
    GameObject persistent;
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
    void Start () {
        audioSource = GetComponent<AudioSource>();
        playerPrefs = GameObject.Find("PlayerPrefs").GetComponent<PlayerPrefs>();
        audioSource.volume = playerPrefs.getVolume();
        playerLives = playerLives - playerPrefs.getDifficulty();
        health = numberOfHits;
        bullets = bullets - playerPrefs.getDifficulty();
        livesText.text = (playerLives).ToString();
        bottlesText.text = numBottles.ToString();
        bottlesText2.text = numBottles.ToString();
        bulletsText.text = bullets.ToString();
        TextBottles.SetActive(false);
        HealthBar.value = getHealth();
        Warning.SetActive(false);
        GameOverObject.SetActive(false);
        StartCoroutine(disableMessage(Initial));
        persistent = GameObject.Find("ScenePersist");
        upperObjects.SetActive(true);
    }

    void Update()
    {
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Success"))
        {
            TextBottles.SetActive(true);
            upperObjects.SetActive(false);
        }
        else
        {
            TextBottles.SetActive(false);
        }
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
        if (!checkpoint)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            SceneManager.LoadScene("Level1 - Checkpoint");
        }
        resetHealth();
        HealthBar.value = getHealth();
        livesText.text = (playerLives-1).ToString();
        Time.timeScale = 1;
    }

    public void GameOverSession()
    {
        Time.timeScale = 0;
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position, playerPrefs.getVolume()); 
        GameOverObject.SetActive(true);
    }

    public void Victory()
    {
        audioSource.Stop();
    }

    public void startAgain()
    {
        SceneManager.LoadScene("Level1");
        Destroy(persistent);
        Destroy(gameObject);
    }

    public void returnMainMenuSession()
    {
        SceneManager.LoadScene("Start Menu");
        Destroy(gameObject);
        Time.timeScale = 1;
        audioSource.Stop();
    }

    public void IncreaseNumBottles()
    {
        numBottles++;
        bottlesText.text = numBottles.ToString();
        bottlesText2.text = numBottles.ToString();
    }

    public void increaseNumBullets()
    {
        bullets++;
        bulletsText.text = bullets.ToString();
    }

    public void decreaseBullets()
    {
        bullets--;
        bulletsText.text = bullets.ToString();
    }

    public bool canShoot()
    {
        if (bullets > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void takeHit()
    {
        health--;
        HealthBar.value = getHealth();
    }

    public float getHealth()
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
        yield return new WaitForSeconds(2.5f);
        name.SetActive(false);
    }

    public void Checkpoint()
    {
        checkpoint = true;
    }
}
