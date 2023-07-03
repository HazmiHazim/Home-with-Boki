using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEndResult : MonoBehaviour
{
    //string scoreKey = "Score";
    public Text LevelCompleteText;
    private static int score;
    //public Text feedback;

    void Start()
    {
        
    }

    void Update()
    {
        score = AnswerMainCam.currentScore;

        LevelCompleteText.text = "Keep it up! Your score was " + score + "!";
    }

}
