using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool IsHide = false;

    void Start()
    {
        //gameObject.SetActive(false);
    }

    void Update()
    {
        if (IsHide)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (IsHide)
        {
            //if (collision.gameObject.tag == "Player")
            //{
            gameObject.SetActive(false);
            //}
        }
        else
        {
            gameObject.SetActive(true);
        }*/
        }

}
