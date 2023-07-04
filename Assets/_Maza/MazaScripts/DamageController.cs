using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int obstacleDamage;
    [SerializeField] private HealthBar healthcontroller;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            sfxManager.PlaySound("enemy collide");

            Damage();
        }
    }

    public void Damage()
    {
        healthcontroller.playerHealth = healthcontroller.playerHealth - obstacleDamage;
        healthcontroller.UpdateHealth();
        //gameObject.SetActive(false);
    }
}
