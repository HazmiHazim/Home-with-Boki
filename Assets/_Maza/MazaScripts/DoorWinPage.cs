using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWinPage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            //BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            SceneManager.LoadScene("Win");
        }
    }
}
