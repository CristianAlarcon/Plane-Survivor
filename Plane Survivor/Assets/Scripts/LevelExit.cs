using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMotionFactor = 0.2f;
    Player player;
    GameSession gameSession;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        player.becomeInmortal();
        Time.timeScale = LevelExitSlowMotionFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        gameSession.Victory();
    }
}
