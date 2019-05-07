using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void StartFirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        if (GameObject.Find("GameSession") != null)
        {
            Destroy(GameObject.Find("GameSession"));
        }
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options Menu");
    }

}
