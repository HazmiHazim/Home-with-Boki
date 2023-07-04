using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static string SceneName;


    //public void PlayGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void btn_Change(string name)
    {
        this.gameObject.SetActive(true);
        SceneName = name;

    }

    public void ObjectInactive()
    {
        this.gameObject.SetActive(false);
    }

    public void JumpScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Debug.Log("WE QUIT THE GAME");
        Application.Quit();
    }
}
