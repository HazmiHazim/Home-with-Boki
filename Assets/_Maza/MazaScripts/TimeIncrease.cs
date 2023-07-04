using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeIncrease : MonoBehaviour
{
    public Timer timer;

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Box")
        {
            sfxManager.PlaySound("fruit");
            Destroy (other.gameObject);
            timer.currentTime += 10;
            }
    }
}
