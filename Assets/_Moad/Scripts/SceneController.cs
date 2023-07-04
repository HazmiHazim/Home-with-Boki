using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Screen, Mainmenu,character;

    private void Start()
    {
        StartCoroutine(title());
    }


    public IEnumerator title()
    {
        yield return new WaitForSeconds(4f);
        Screen.SetActive(false);
        character.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void LoadAdditionOrSubtraction(int index)
    {
        //if(index==0)
        //{
        //    PlayerPrefs.SetInt("key", 0);
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("key", 1);

        //}
        SceneManager.LoadScene(1);
    }

    public void LoadMultiplicationOrSubtraction(int index)
    {
        //if (index == 0)
        //{
        //    PlayerPrefs.SetInt("key", 2);

        //}
        //else
        //{
        //    PlayerPrefs.SetInt("key", 3);

        //}
        SceneManager.LoadScene(1);
    }
}
