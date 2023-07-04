using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth1 : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    //public SpriteRenderer playerSr;
    //public PlayerController playerControl;

    public GameObject panelGameOver;
    public bool gameOver = false;
    public GameObject panelWin;
    public bool win = false;

    public Sprite emptyHeart;
    public Sprite fullHeart;

    public Image[] hearts;

    //  public Timer time;


    void Start()
    {
        health = maxHealth;

    }
    public void TakeDamage(int amount)  //amount = how much damage the player takes
    {
        health -= amount;

        if (health <= 0)
        {
            //playerSr.enabled = false;
            //playerControl.enabled = false;


          //  if (time.TimeLeft > 0)
                panelGameOver.SetActive(true);
                gameOver = true;
                panelWin.SetActive(false);
                win = false;
            //    time.TimerOn = false;
          //  }




            //PanelOpener();

        }
    }

    void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    // public void PanelOpener()
    // {
    //if (panelGameOver != null)
    //{
    //    bool isActive = panelGameOver.activeSelf;
    //    panelGameOver.SetActive(!isActive);
    // }
    // }

}
