using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static int numberOfCupcakes;

    private void Awake()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Home");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Module1");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Module3");
    }
}
