using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerWrong : MonoBehaviour
{
    public int value;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sfxManager.PlaySound("wrong");

            Destroy(gameObject);
            AnswerMainCam.instance.DecreaseScore(value);
        }
    }
}
