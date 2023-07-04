using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerMainCam : MonoBehaviour
{
    public static AnswerMainCam instance;

    public TMP_Text scoreText;
    public static int currentScore;
    //int score;
    //ScoreEndResult scoreendresult;


    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        //scoreendresult = FindObjectOfType<ScoreEndResult>();
        //currentScore = scoreendresult.CurrentScore;
        currentScore = 0;
        scoreText.text = "Score: " + currentScore.ToString();

        //StartCoroutine(SpawnWaveWithDelay)
    }

    public void IncreaseScore(int v)
    {
        currentScore += v;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void DecreaseScore(int v)
    {
        currentScore -= v;
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
