using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool runningTimer;
    public float currentTime;
    public float maxTime = 60;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        runningTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (runningTimer)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "Time:" + System.Math.Round(currentTime,0) + " s";
            Debug.Log(currentTime);

            if (currentTime <= 0)
            {
                runningTimer = false;
                SceneManager.LoadScene("EndGameOver");
            }
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            currentTime += 10;
            Destroy(other.gameObject);
        }

    }*/

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Box")
        {
            if (runningTimer)
            {
                currentTime += 10;
                Destroy(other.gameObject);
            }
            }
    }*/
}
