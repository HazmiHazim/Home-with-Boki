using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManagerScript : MonoBehaviour
{
    public static int life = 3;

    public Image[] hearts;
    public Sprite fullLife;
    public Sprite emptyLife;

    void Awake()
    {
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image image in hearts)
        {
            image.sprite = emptyLife;
        }
        for (int i = 0; i < life; i = i + 1)
        {
            hearts[i].sprite = fullLife;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameManagerScript.numberOfCupcakes++;
            Destroy(gameObject);
        }
    }
}
