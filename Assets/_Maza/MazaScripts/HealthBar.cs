using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int playerHealth;

    [SerializeField] private Image[] hearts;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else if(i == 0)
            {
                SceneManager.LoadScene("EndGameOver");
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    public void UpdateHealth2()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i > playerHealth)
            {
                hearts[i].color = Color.black;
            }
            else
            {
                hearts[i].color = Color.red;
            }
        }
    }
}
