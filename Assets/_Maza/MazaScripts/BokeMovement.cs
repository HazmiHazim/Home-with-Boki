using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BokeMovement : MonoBehaviour
{
    float moveInput;
    public Rigidbody2D rb;
    public float speed;
    public Transform pos;
    public float radius;
    public LayerMask groundLayers;
    public float jumpforce;
    public float heightCutter;
    bool grounded;
    public bool deathState = false;
    private bool facingRight = false;
    float lockPos = 0;
    [HideInInspector]

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        grounded = Physics2D.OverlapCircle(pos.position, radius, groundLayers);

        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            sfxManager.PlaySound("jump");

            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            sfxManager.PlaySound("jump");

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * heightCutter);
            }
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "35" && other.gameObject.tag == "6" && other.gameObject.tag == "72" && other.gameObject.tag == "144")
        {
            Key.IsHide = false;
        }
        /*else if (other.gameObject.tag == "targetkey")
        {
            Key.IsHide = false;
        }
    }

    void keyVisible()
    {
        key.gameObject.SetActive(true);
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Key.IsHide)
        {
            if (collision.gameObject.tag == "35" && collision.gameObject.tag == "6" && collision.gameObject.tag == "72" && collision.gameObject.tag == "144")
            {
                Key.IsHide = false;
            }
            else
            {
                SceneManager.LoadScene("EndGameOver");
            }

            if (collision.gameObject.tag == "key")
            {
                Key.IsHide = true;
            }
        }
    }
}
