using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    //public static PlayerHealth instance;

    public int health = 3;

    public Image [] Heart;

    private Animator anim;

    public AudioSource damageSound;
   

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(transform.position.y < -11f)
        {
            TakeDamage(1);
            transform.position = Vector3.zero;
        }
        if (health < 1)
        {

            StartCoroutine(PlayersDeath());
        }
    }

    IEnumerator PlayersDeath()
    {
        anim.SetBool("Death", true);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        yield return new WaitForSeconds(.1f);
        anim.SetBool("Death", false);
       // gamemaneger.instance.NextLevel("You Lose");
        yield return new WaitForSeconds(.5f);
       // SoundManager.instance.PlayerDeath();
        Destroy(this.gameObject);
        //Time.timeScale=0;
        //yield return new WaitForSeconds(0.5f);
         SceneManager.LoadScene(0);
       
    }

    public void TakeDamage(int damage)
    {
        ///  SoundManager.Instance.PlaydeathSound();
        damageSound.Play();
        health -= damage;
 Heart[health].gameObject.SetActive(false);
 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("score"))
        {
            GameManager.Instance.UpdateScore(10);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("health"))
        {
            Destroy(collision.gameObject);
            if (health<3)
            {
                health += 1;
                Heart[health-1].gameObject.SetActive(true);
              

            }
        }
        if (collision.gameObject.CompareTag("key"))
        {
           
            Destroy(collision.gameObject);
        }
    }

}
