using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (LifeManagerScript.life == 3)
            {
                AudioManager.instance.Play("Collect Sound");
                Destroy(gameObject);
            }
            else if (LifeManagerScript.life < 3)
            {
                AudioManager.instance.Play("Collect Sound");
                LifeManagerScript.life = LifeManagerScript.life + 1;
                Destroy(gameObject);
            }
        }
    }
}
