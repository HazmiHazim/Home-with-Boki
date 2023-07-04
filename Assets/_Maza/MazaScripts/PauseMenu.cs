using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] Image PlayICON;
    [SerializeField] Image PauseICON;


    void Start()
    {
        PlayICON.enabled = true;
        PauseICON.enabled = false;
    }

    public void Pause()
    {
        sfxManager.PlaySound("click");

        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;

        PauseICON.enabled = true;
        PlayICON.enabled = false; 
    }

    public void Resume()
    {
        sfxManager.PlaySound("click");

        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;

        PlayICON.enabled = true;
        PauseICON.enabled = false;
    }

    public void Restart()
    {
        sfxManager.PlaySound("click");

        Time.timeScale = 1f;
        SceneManager.LoadScene("MultiplyModule");

        PlayICON.enabled = true;
        PauseICON.enabled = false;
    }

    public void Exit()
    {
        sfxManager.PlaySound("click");

        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        SceneManager.LoadScene("ChooseLevel");
        //PauseICON.enabled = true;
        //PlayICON.enabled = false;
    }
}
