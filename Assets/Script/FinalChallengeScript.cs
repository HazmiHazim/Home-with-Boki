using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChallengeScript : MonoBehaviour
{
    public GameObject spellingQuizPanel;
    private PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            spellingQuizPanel.SetActive(true);
        }
    }
}
