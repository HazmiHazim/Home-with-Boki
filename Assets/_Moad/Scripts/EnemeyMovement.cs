using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{
    //public static EnemeyMovement instance;

    Rigidbody2D rb;
 


    [Header("Movement")]
    public float MovementSpeed;
    float Minx, MaxX;
    [SerializeField] float Distance;
    [SerializeField] int Direction;
    public  bool Petrol;
    int dir;
    [SerializeField] bool IsMob;


   


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }
    private void Start()
    {
        if(IsMob)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
     
        MaxX = transform.position.x + Distance;
        Minx = MaxX - Distance;
        
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
       
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(dir, transform.localScale.y);
           
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-(dir), transform.localScale.y);
        }
        if (Petrol)
        {
            switch (Direction)
            {
                case -1:
                    if (transform.position.x > Minx)
                    {
                        rb.velocity = new Vector2(-MovementSpeed, rb.velocity.y);
                    }
                    else
                    {
                        Direction = 1;
                    }
                    break;
                case 1:
                    if (transform.position.x < MaxX)
                    {
                        rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);
                    }
                    else
                    {
                        Direction = -1;
                    }
                    break;
            }
            //Debug.Log("switch working");
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
