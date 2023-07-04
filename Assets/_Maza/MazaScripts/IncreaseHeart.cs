using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHeart : MonoBehaviour
{
    [SerializeField] private int heartUp;
    [SerializeField] private HealthBar healthcontroller;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Heal();
            Destroy(gameObject);
        }

    }

    public void Heal()
    {
        sfxManager.PlaySound("fruit");

        healthcontroller.playerHealth = healthcontroller.playerHealth + heartUp;
        healthcontroller.UpdateHealth2();
        
    }
}
