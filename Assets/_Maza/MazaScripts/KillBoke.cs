using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            //BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            SceneManager.LoadScene("EndGameOver");
        }
    }
}
