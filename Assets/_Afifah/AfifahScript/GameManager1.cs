using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Platformer
{
    public class GameManager1 : MonoBehaviour
    {
        public int scoreCounter = 0;
        public GameObject playerGameObject;
        private PlayerController1 player;
        //public GameObject deathPlayerPrefab;
        public Text scoreText;

        public Sprite emptyStar;
        public Sprite fullStar;
        public Image[] stars;
        public Text finalScore;

       // public Timer time;

        public GameObject panelGameOver;
        public bool gameOver = false;
        public GameObject panelWin;
        public bool win = false;
        public EnemyAI1 enemy;

        public GameObject finish;

        public bool isFinish = false;

        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController1>();
         //   finish = GameObject.FindGameObjectWithTag("finish");

        }
        void Update()
        {
            scoreText.text = scoreCounter.ToString();
            finalScore.text = scoreCounter.ToString();
            //if (player.deathState == true)
            // {
            //  playerGameObject.SetActive(false);
            // GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
            // deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
            // player.deathState = false;
            // Invoke("ReloadLevel", 3);
            // }

            for (int i = 0; i < stars.Length; i++)
            {
                if (scoreCounter >= 500)
                {
                    stars[0].sprite = fullStar;
                    stars[1].sprite = fullStar;
                    stars[2].sprite = fullStar;
                }
                else if (scoreCounter < 500 && scoreCounter >= 300)
                {
                    stars[0].sprite = fullStar;
                    stars[1].sprite = fullStar;
                    stars[2].sprite = emptyStar;
                }

                else if (scoreCounter < 300 && scoreCounter >= 200)
                {
                    stars[0].sprite = fullStar;
                    stars[1].sprite = emptyStar;
                    stars[2].sprite = emptyStar;
                }

                else if (scoreCounter < 200 && scoreCounter > 0)
                {
                    stars[0].sprite = emptyStar;
                    stars[1].sprite = emptyStar;
                    stars[2].sprite = emptyStar;
                }
            }

           // if (time.TimeLeft > 0)
          //  {
                if (isFinish == true)
                {
             //       enemy.enemySr.enabled = false;
           //         enemy.enemyMovement.enabled = false;
             //       time.TimerOn = false;
                    panelWin.SetActive(true);
                    win = true;
                    panelGameOver.SetActive(false);
                    gameOver = false;
                }


          //  }
        //    else if (time.TimeLeft == 0)
         //   {
         //
           //     enemy.enemySr.enabled = false;
           //     enemy.enemyMovement.enabled = false;
           //     time.TimerOn = false;
          //      panelGameOver.SetActive(true);
          //      gameOver = true;
          //      panelWin.SetActive(false);
          //      win = false;

          //  }


        }


        //private void ReloadLevel()
        //{
        // Application.LoadLevel(Application.loadedLevel);
        //}
    }
}