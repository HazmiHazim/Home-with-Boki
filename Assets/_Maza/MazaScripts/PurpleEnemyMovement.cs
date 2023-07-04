using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PurpleEnemyMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    bool facingLeft;

    [SerializeField] private int obstacleDamage;
    [SerializeField] private HealthBar healthcontroller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage();
            //SceneManager.LoadScene("EndGameOver");
        } 

        if (collision != null && !collision.collider.CompareTag("Player") && collision.collider.CompareTag("Ground"))
        {
            facingLeft = !facingLeft;
        }

        /*if (collision != null && !collision.collider.CompareTag("Player") && collision.collider.CompareTag("Spike"))
        {
            facingLeft = !facingLeft;
        }*/

        if (facingLeft)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Damage()
    {
        sfxManager.PlaySound("enemy collide");

        healthcontroller.playerHealth = healthcontroller.playerHealth - obstacleDamage;
        healthcontroller.UpdateHealth();
        //gameObject.SetActive(false);
    }
}
