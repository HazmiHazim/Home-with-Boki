using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellingQuizScript : MonoBehaviour
{
    public TMP_Text wordText;
    public Button button1;
    public Button button2;
    public Button button3;
    public int maxTries = 2;

    //private string targetWord = "B A _ A N A";
    private int currentTries = 0;

    public GameObject panel;
    public GameObject nextLevelScreen;

    private void Start()
    {
        button1.onClick.AddListener(() => OnButtonClick("W"));
        button2.onClick.AddListener(() => OnButtonClick("P"));
        button3.onClick.AddListener(() => OnButtonClick("N"));
    }

    private void OnButtonClick(string letter)
    {
        if (letter == "N")
        {
            AudioManager.instance.Play("Correct Answer Sound");
            if (LifeManagerScript.life == 3)
            {
                Debug.Log("Congratulations! You spelled the word correctly.");
                SetButtonColor(button3, Color.green);
            }
            else if (LifeManagerScript.life < 3)
            {
                Debug.Log("Congratulations! You spelled the word correctly.");
                SetButtonColor(button3, Color.green);
                LifeManagerScript.life = LifeManagerScript.life + 1;
            }
            nextLevelScreen.SetActive(true);
            Time.timeScale = 1;
        }
        else
        {
            currentTries++;
            Debug.Log("Wrong letter. Try again.");

            if (currentTries >= maxTries)
            {
                ClosePanel();
                LifeManagerScript.life = LifeManagerScript.life - 1;
                if (LifeManagerScript.life <= 0)
                {
                    Time.timeScale = 0;
                    GameManagerScript.isGameOver = true;
                    AudioManager.instance.Play("Game Over Sound");
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void ClosePanel()
    {
        panel.SetActive(false);
        currentTries = 0;
        Time.timeScale = 1;
    }

    private void SetButtonColor(Button button, Color color)
    {
        Image buttonImage = button.GetComponent<Image>();
        buttonImage.color = color;
    }
}
